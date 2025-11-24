using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float kickPushForce = 10f, kickLiftForce = 5f;
    [SerializeField] private int damage = 1;

    [SerializeField] private KickDetection kickDetection;

    private void Start()
    {
        InputManager.Instance.inputs.Playing.Kick.performed += Kick;
    }

    private void OnDisable()
    {
        InputManager.Instance.inputs.Playing.Kick.performed -= Kick;
    }

    public void Kick(InputAction.CallbackContext ctx) 
    {
        foreach(IKickable obj in kickDetection.kickableObjectsBeingDetected) 
        {
            obj.GetKicked(gameObject, kickPushForce, kickLiftForce, damage, transform);
        }
    }
}
