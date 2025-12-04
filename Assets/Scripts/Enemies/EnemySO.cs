using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class EnemySO : ScriptableObject
{
    public float speed;

    public abstract void GetKicked(GameObject player, float kickForce, float liftForce, int kickDamage, Transform playerTrans, Transform transform, Rigidbody rb);

}
