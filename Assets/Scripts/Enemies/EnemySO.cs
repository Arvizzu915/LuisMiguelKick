using UnityEngine;


public abstract class EnemySO : ScriptableObject, IKickable
{
    public float speed;

    public abstract void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans);
}
