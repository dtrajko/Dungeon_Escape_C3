using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Handle to Animator
    private Animator _animator;
    // private Animator _swordAnimation;


    // Start is called before the first frame update
    void Start()
    {
        // Assign Handle to Animator
        _animator = GetComponentInChildren<Animator>();
        // _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move) {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping) {
        _animator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        // _swordAnimation.SetTrigger("SwordAnimation");
    }

    public void Death() {
        _animator.SetTrigger("Death");
    }
}
