using UnityEngine;

[CreateAssetMenu(fileName = "ChaseEnemy", menuName = "Enemy")]
public class ChaseEnemy : EnemySO, IKickable
{
    public override void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans, Transform myTrans, Rigidbody myRb)
    {
        float liftForceRand = Random.Range(.1f, liftForce);

        Vector3 kickDir = (myTrans.position - playerTrans.position).normalized;
        kickDir = new Vector3(kickDir.x, liftForceRand, kickDir.z);

        myRb.AddForce(kickDir * kickForce, ForceMode.Impulse);
    }
}
