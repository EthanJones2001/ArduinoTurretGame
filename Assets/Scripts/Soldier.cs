using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Enemy
{

    void Update()
    {
        if (player != null)
        {
            Move(player);
        }
    }

    public override void Move(Transform player)
    {
        base.Move(player);
    }

    protected override void Death()
    {
        base.Death();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Death();
        }
    }
}
