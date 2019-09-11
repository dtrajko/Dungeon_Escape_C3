using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Attacking " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null) {
            hit.Damage();
        }
    }
}
