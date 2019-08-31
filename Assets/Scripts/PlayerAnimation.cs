using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Handle to Animator
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        // Assign Handle to Animator
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move) {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }
}
