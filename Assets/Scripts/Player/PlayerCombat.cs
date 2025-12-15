using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float kickPushForce = 10f;
    [SerializeField] private float kickLiftForce = 5f;
    [SerializeField] private int damage = 1;

    [SerializeField] private KickDetection kickDetection;

    [Header("Kick Timing")]
    [SerializeField] private float kickCooldown = 0.25f;
    [SerializeField] private float bufferTime = 0.15f;

    private bool canKick = true;
    private float bufferTimer = 0f;

    private void Start()
    {
        InputManager.Instance.inputs.Playing.Kick.performed += OnKickInput;
    }

    private void OnDisable()
    {
        InputManager.Instance.inputs.Playing.Kick.performed -= OnKickInput;
    }

    private void Update()
    {
        // decrease buffer timer
        if (bufferTimer > 0)
        {
            bufferTimer -= Time.deltaTime;

            // If we buffered a kick and an enemy appears, kick immediately
            if (kickDetection.kickablesDetected.Count > 0 && canKick)
            {
                ExecuteKick();
                bufferTimer = 0;
            }
        }
    }

    private void OnKickInput(InputAction.CallbackContext ctx)
    {
        // Already in range → kick immediately
        if (kickDetection.kickablesDetected.Count > 0 && canKick)
        {
            ExecuteKick();
            return;
        }

        // Otherwise activate buffer
        bufferTimer = bufferTime;
    }

    private void ExecuteKick()
    {
        if (!canKick)
            return;

        canKick = false;

        // Apply kick to each detected target only once
        List<IKickable> targets = new(kickDetection.kickablesDetected);

        foreach (IKickable target in targets)
        {
            target.GetKicked(gameObject, kickPushForce, kickLiftForce, damage, transform);
        }

        // start cooldown
        Invoke(nameof(ResetKick), kickCooldown);
    }

    private void ResetKick()
    {
        canKick = true;
    }
}
