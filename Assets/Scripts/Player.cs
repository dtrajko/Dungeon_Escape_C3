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
    private float localScaleX;

    // Start is called before the first frame update
    void Start()
    {
        // Assign handle of Rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        localScaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        // Horizontal input for left / right
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededCoroutine());
        }

        if (move < -0.1f) localScaleX = -1;
        if (move > 0.1f) localScaleX = 1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

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
}
