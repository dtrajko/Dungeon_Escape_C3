using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject acidEffectPrefab;
    [SerializeField] private float attackCooldown = 6.0f;

    private float attackCooldownTimer;

    public override void Init()
    {
        base.Init();
        Health = base.Health;
        attackCooldownTimer = attackCooldown;
    }

    public override void Movement()
    {
        attackCooldownTimer -= Time.deltaTime;

        if (attackCooldownTimer < 0.0f)
        {
            attackCooldownTimer = attackCooldown;
        }

        // 1.55 seconds - the duration of the Spider Idle animation
        if (attackCooldownTimer < 1.550f && attackCooldownTimer > 0.0f)
        {
            animator.SetBool("InCombat", true);
        }
        else {
            animator.SetBool("InCombat", false);
        }
    }

    public void Attack() {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
