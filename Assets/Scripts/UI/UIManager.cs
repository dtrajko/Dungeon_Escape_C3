using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerGemCountText;
    public Image selectionImage;

    private static UIManager _instance;

    private void Awake() {
        _instance = this;
    }

    public static UIManager Instance {
        get {
            if (_instance == null)
            {
                Debug.LogError("UIManager instance is NULL!");
            }
            return _instance;
        }
    }

    public void OpenShop(int gemCount) {
        playerGemCountText.text = gemCount + "G";
    }

}
