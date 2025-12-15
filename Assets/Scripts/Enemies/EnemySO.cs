using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class EnemySO : ScriptableObject
{
    public float speed;

    public abstract void GetKicked(GameObject player, float kickForce, float liftForce, int kickDamage, Transform playerTrans, Enemy objScript);

    public virtual void InitializeSO(Enemy enemy)
    {
        if (enemy.agent.enabled)
        {
            enemy.agent.SetDestination(PlayerManager.instance.transform.position);

            enemy.currentSpeed = speed;

            enemy.agent.speed = enemy.currentSpeed;
        }
    }


    public virtual void UpdateSO(Enemy enemy)
    {
        if (enemy.agent.enabled)
        {
            enemy.agent.SetDestination(PlayerManager.instance.transform.position);
        }
    }
}
