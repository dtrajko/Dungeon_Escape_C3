using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    // Get reference to Rigidbody
    [SerializeField] private float _jumpForce = 6.5f;
    [SerializeField] private bool _grounded = false;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] protected int health = 100;

    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordArcSpriteRenderer;
    private float _swordArcPositionX;
    private float _swordArcRotationX;

    protected Animator animator;
    protected bool isHit = false;

    public int Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Assign handle of Rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        animator = GetComponentInChildren<Animator>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _swordArcPositionX = _swordArcSpriteRenderer.transform.localPosition.x;
        _swordArcRotationX = _swordArcSpriteRenderer.transform.localRotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && IsGrounded()) {
            _playerAnimation.Attack();
        }
    }

    void Movement() {
        // Horizontal input for left / right
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        Flip(move);

        if (IsGrounded() && (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))) {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpCoroutine());
            _playerAnimation.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _playerAnimation.Move(move);
    }

    bool IsGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer.value);
        // Debug.DrawRay(transform.position, Vector3.down, Color.green, 0.8f);
        if (hitInfo.collider != null) {
            if (_resetJump == false) {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpCoroutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Flip(float move) {
        if (move > 0)
        {
            _playerSpriteRenderer.flipX = false;
            // _swordArcSpriteRenderer.flipX = false;
            _swordArcSpriteRenderer.flipY = false;
            _swordArcSpriteRenderer.transform.localPosition = new Vector3(
                _swordArcPositionX,
                _swordArcSpriteRenderer.transform.localPosition.y,
                _swordArcSpriteRenderer.transform.localPosition.z
            );
            _swordArcSpriteRenderer.transform.localRotation = Quaternion.Euler(
                _swordArcRotationX,
                _swordArcSpriteRenderer.transform.localRotation.eulerAngles.y,
                _swordArcSpriteRenderer.transform.localRotation.eulerAngles.z
            );
        }
        else if (move < 0)
        {
            _playerSpriteRenderer.flipX = true;
            // _swordArcSpriteRenderer.flipX = true;
            _swordArcSpriteRenderer.flipY = true;
            _swordArcSpriteRenderer.transform.localPosition = new Vector3(
                -_swordArcPositionX,
                _swordArcSpriteRenderer.transform.localPosition.y,
                _swordArcSpriteRenderer.transform.localPosition.z
            );
            _swordArcSpriteRenderer.transform.localRotation = Quaternion.Euler(
                -_swordArcRotationX,
                _swordArcSpriteRenderer.transform.localRotation.eulerAngles.y,
                _swordArcSpriteRenderer.transform.localRotation.eulerAngles.z
            );
        }
    }

    public void Damage()
    {
        Health--;
        // Debug.Log("Player Damage() called. Health: " + Health);

        if (Health > 0)
        {
            animator.SetTrigger("Hit");
            isHit = true;
        }

        // animator.SetBool("InCombat", true);
        if (Health <= 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 5.0f);
        }
    }
}
