using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform kickPosition;
    [SerializeField] private LayerMask kickMask;
    [SerializeField] private float kickPushForce = 10f, kickExplosionLiftForce = 5f, kickRadius = 5f;
    [SerializeField] private int damage = 1;

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
        Debug.Log("kck");
        PushEnemies();
    }

    private void PushEnemies()
    {
        Collider[] targetsInArea = Physics.OverlapSphere(kickPosition.position, kickRadius, kickMask, QueryTriggerInteraction.Ignore);
        foreach (Collider target in targetsInArea)
        {
            Debug.Log(target.name);
            if (target.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(kickPushForce, kickPosition.position, kickRadius, kickExplosionLiftForce, ForceMode.Impulse);
            }
        }

    }
}
