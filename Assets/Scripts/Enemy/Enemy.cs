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
    protected bool isHit = false;

    protected Player player;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement() {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("InCombat") == false)
        {
            // isHit = false;
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

        if (isHit == false) {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 2.0f) {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.position - transform.position;

        if (animator.GetBool("InCombat"))
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0) {
                spriteRenderer.flipX = true;
            }

            // if (transform.name == "Skeleton_Enemy") {
            //     Debug.Log(transform.name + " Orientation: " + (direction.x > 0 ? "Right" : "Left"));
            // }
        }

    }
}
