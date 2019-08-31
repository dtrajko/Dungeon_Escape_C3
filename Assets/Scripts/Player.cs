using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Get reference to Rigidbody
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private bool _grounded = false;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigid;
    private bool resetJumpNeeded = false;

    // Start is called before the first frame update
    void Start()
    {
        // Assign handle of Rigidbody
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal input for left / right
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (CrossPlatformInputManager.GetButtonDown("Jump") && _grounded) {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededCoroutine());
        }

        // 2D raycast to the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null) {
            if (resetJumpNeeded == false) {
                _grounded = true;
            }
        }
        _rigid.velocity = new Vector2(move * _moveSpeed, _rigid.velocity.y);
    }

    IEnumerator ResetJumpNeededCoroutine() {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }
}
