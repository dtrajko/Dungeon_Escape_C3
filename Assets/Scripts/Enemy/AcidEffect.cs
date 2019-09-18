using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private void Start() {
        Destroy(gameObject, 5.0f);
    }

    private void Update() {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null) {
                hit.Damage();
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
