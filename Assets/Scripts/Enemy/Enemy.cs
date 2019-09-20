using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected GameObject diamondPrefab;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected bool bSwitch;
    protected bool isHit = false;
    protected Player player;

    public int Health { get => health; set => health = value; }

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

        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) &&
            animator.GetBool("InCombat") == false)
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

        if (isHit == false) {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = 1000.0f;
        if (player != null) {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }

        if (distance > 2.0f) {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        Vector3 direction = new Vector3();
        if (player != null) {
            direction = player.transform.position - transform.position;
        }

        if (animator.GetBool("InCombat") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0) {
                spriteRenderer.flipX = true;
            }
        }
    }

    public void Damage()
    {
        Health--;
        // Debug.Log(GetType().Name + " damaged. Health: " + Health);

        if (Health > 0)
        {
            animator.SetTrigger("Hit");
            isHit = true;
            animator.SetBool("InCombat", true);
        }

        if (Health <= 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 5.0f);
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().Gems = gems;
        }
    }
}
