using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;

    public void Attack() {
        Debug.Log("My name is " + this.gameObject.name);
    }

}
