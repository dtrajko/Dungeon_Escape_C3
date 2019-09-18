using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();
    }

    public override void Movement()
    {
        // Sit still
    }

    public void Attack() {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
