using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IKickable
{
    [Header("Main Components")]
    public Rigidbody mainRB;                  // Kinematic rigidbody for trigger detection
    public Collider mainCollider;             // The trigger/detection collider
    public NavMeshAgent agent;
    public Animator animator;
    public EnemySO enemySO;

    [Header("Ragdoll")]
    public Rigidbody[] ragdollRBs;
    public Collider[] ragdollCols;

    [Header("State")]
    public float currentSpeed;
    public bool ragdolled = false;

    [Header("Knock Settings")]
    public float knockRecoverTime = 5f;

    // MUST BE PUBLIC
    public Coroutine knockRoutine;

    private void Start()
    {
        SetRagdoll(false);
        enemySO.InitializeSO(this);
    }

    private void OnEnable()
    {
        // Reset main rigidbody
        if (mainRB != null)
        {
            mainRB.isKinematic = true;
        }

        // Reset navmesh
        if (agent != null)
        {
            agent.enabled = true;
            agent.Warp(transform.position);
        }

        animator.enabled = true;
        mainCollider.enabled = true;

        SetRagdoll(false);

        // Ensure coroutine field is clean
        knockRoutine = null;
    }

    public void GetKicked(GameObject player, float kickForce, float liftForce, int kickDamage, Transform playerTrans)
    {
        enemySO.GetKicked(player, kickForce, liftForce, kickDamage, playerTrans, this);
    }

    // ---------------------------
    // RAGDOLL CONTROL
    // ---------------------------
    public void SetRagdoll(bool active)
    {
        ragdolled = active;

        foreach (var rb in ragdollRBs)
            rb.isKinematic = !active;

        foreach (var col in ragdollCols)
            col.enabled = active;

        animator.enabled = !active;

        if (active)
        {
            agent.enabled = false;

            // Disable main kinematic RB so it stops fighting ragdoll
            mainRB.isKinematic = false;
            mainCollider.enabled = false;
        }
        else
        {
            agent.enabled = true;
            animator.enabled = true;

            // Restore kinematic body
            mainRB.isKinematic = true;
            mainCollider.enabled = true;
        }
    }

    public IEnumerator KnockRoutine()
    {
        SetRagdoll(true);

        yield return new WaitForSeconds(knockRecoverTime);

        gameObject.SetActive(false);   // back to pool
    }
}
