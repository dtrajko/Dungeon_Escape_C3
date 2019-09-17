using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public override void Init()
    {
        base.Init();
    }

    public override void Movement()
    {
        base.Movement();
    }

    public int Health { get => health; set => health = value; }

    public void Damage()
    {
        Health--;

        Debug.Log(GetType().Name + " damaged. Health: " + Health);

        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
