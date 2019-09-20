using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private int gems = 1;

    public int Gems { get => gems; set => gems = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null) {
                player.Diamonds += gems;
            }

            Destroy(gameObject);
        }
    }
}
