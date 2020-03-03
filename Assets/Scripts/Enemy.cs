using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int health;
    public NavMeshAgent agent;
    public Transform player;

    public virtual void Damage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        if (health == 0)
            Death();
    }

    public virtual void Move(Transform direction)
    {
        agent.SetDestination(direction.position);
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
