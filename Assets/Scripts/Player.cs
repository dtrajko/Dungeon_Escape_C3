using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Get reference to Rigidbody
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private bool _grounded = false;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 2.5f;

    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Assign handle of Rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        // Horizontal input for left / right
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        Flip(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededCoroutine());
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _playerAnimation.Move(move);
    }

    bool IsGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer.value);
        if (hitInfo.collider != null) {
            if (_resetJump == false) {
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpNeededCoroutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Flip(float move) {
        if (move > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
