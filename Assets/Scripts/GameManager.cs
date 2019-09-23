using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public bool hasKeyToCastle = false;

    private void Awake()
    {
        _instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager instance is NULL!");
            }
            return _instance;
        }
    }

    public bool HasKeyToCastle { get => hasKeyToCastle; set => hasKeyToCastle = value; }
}
