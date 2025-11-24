using UnityEngine;

public interface IKickable
{
    public void GetKicked(GameObject Player, float kickForce, float liftForce, int kickDamage, Transform playerTrans);
}