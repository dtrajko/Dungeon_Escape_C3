﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private bool _switch;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _currentTarget;
    private Animator _animator;

    // Start is called before the first frame update
    void Start() {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _currentTarget = pointB.position;
        _animator = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            return;
        }
        Movement();
    }

    void Movement() {
        if (transform.position == pointA.position)
        {
            _switch = false;
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _switch = true;
            _currentTarget = pointA.position;
        }

        Flip(_switch);
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

    void Flip(bool _switch)
    {
        _spriteRenderer.flipX = _switch;
    }
}
