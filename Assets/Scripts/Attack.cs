using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Attacking " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null && _canDamage == true) {
            hit.Damage();
            _canDamage = false;
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator ResetDamage() {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
