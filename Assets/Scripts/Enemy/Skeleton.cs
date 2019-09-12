using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public override void Init()
    {
        base.Init();
    }

    public override void Movement()
    {
        base.Movement();
    }

    int IDamageable.Health { get => health; set => health = value; }

    void IDamageable.Damage()
    {
        health--;
        animator.SetTrigger("Hit");
        isHit = true;
        // Debug.Log(GetType().Name + " damaged. Health: " + health);
        if (health < 1) {
            Destroy(gameObject, 1.0f);
        }
    }
}
