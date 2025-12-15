using UnityEngine;

[CreateAssetMenu(fileName = "ChaseEnemy", menuName = "EnemyTypes/Chase")]
public class ChaseEnemy : EnemySO
{
    public override void GetKicked(GameObject player, float kickForce, float liftForce, int kickDamage, Transform playerTrans, Enemy enemy)
    {
        if (enemy.knockRoutine != null)
            enemy.StopCoroutine(enemy.knockRoutine);

        enemy.knockRoutine = enemy.StartCoroutine(enemy.KnockRoutine());

        // Apply force to ragdoll root AFTER ragdoll is active
        Vector3 dir = (enemy.transform.position - playerTrans.position).normalized;
        dir.y = Random.Range(.1f, liftForce);

        // Apply force to the main rigidbody (now non-kinematic)
        enemy.mainRB.AddForce(dir * kickForce, ForceMode.Impulse);
    }
}
