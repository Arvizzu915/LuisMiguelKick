using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private EnemySO enemySO;

    public void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans)
    {
        enemySO.GetKicked(Player, kickForce, liftForce, kickDamage, playerTrans, transform, rb);
        
    }
}
