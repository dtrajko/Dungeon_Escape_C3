using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Get reference to Rigidbody
    private Rigidbody2D _rigid;

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
        float horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
    }
}
