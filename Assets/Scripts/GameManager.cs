using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private Player _player;

    public bool hasKeyToCastle = false;

    private void Awake()
    {
        _instance = this;
        _player = FindObjectOfType<Player>();
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

    public Player Player { get => _player; private set { } }
}
