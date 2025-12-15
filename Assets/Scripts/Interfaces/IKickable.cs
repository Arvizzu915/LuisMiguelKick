using UnityEngine;

public interface IKickable
{
    public void GetKicked(GameObject player, float kickForce, float liftForce, int kickDamage, Transform playerTrans);
}