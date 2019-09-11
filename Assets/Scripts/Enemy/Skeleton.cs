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
        Debug.Log(GetType().Name + " damaged.");
    }
}
