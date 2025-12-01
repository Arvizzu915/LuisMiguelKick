using UnityEngine;

[CreateAssetMenu(fileName = "ChaseEnemy", menuName = "Enemy")]
public class ChaseEnemy : EnemySO
{
    public override void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans)
    {
    }
}
