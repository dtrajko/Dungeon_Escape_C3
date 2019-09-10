using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected bool bSwitch;

    private void Start() {
        Init();
    }

    private void Update()
    {
        Movement();
    }

    public virtual void Init() {
        currentTarget = pointB.position;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Movement() {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        spriteRenderer.flipX = bSwitch;

        if (transform.position == pointA.position)
        {
            bSwitch = false;
            currentTarget = pointB.position;
            animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            bSwitch = true;
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
