using UnityEngine;

public class Enemy : MonoBehaviour, IKickable
{
    [SerializeField] private Rigidbody rb;

    public void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans)
    {
        float liftForceRand = Random.Range(.1f, liftForce);

        Vector3 kickDir = (transform.position - playerTrans.position).normalized;
        kickDir = new Vector3(kickDir.x, liftForceRand, kickDir.z);

        rb.AddForce(kickDir * kickForce, ForceMode.Impulse);
        
    }
}
