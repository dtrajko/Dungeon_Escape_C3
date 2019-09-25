using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    [SerializeField] public GameObject panelShop;
    [SerializeField] public GameObject panelHUD;

    public Text playerGemCountText;
    public Image selectionImage;
    public int selectionImageOffsetY = 104;
    public Text gemCountText;

    private void Awake() {
        _instance = this;
        panelHUD.SetActive(true);
        panelShop.SetActive(false);
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

    public void UpdateShopSelection(int index) {
        float selImageAnchorPosY = 0;
        switch (index)
        {
            case 0:
                selImageAnchorPosY = selectionImageOffsetY;
                break;
            case 1:
                selImageAnchorPosY = 0;
                break;
            case 2:
                selImageAnchorPosY = -selectionImageOffsetY;
                break;
        }
        selectionImage.rectTransform.anchoredPosition = new Vector2(
            selectionImage.rectTransform.anchoredPosition.x,
            selImageAnchorPosY
        );
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }
}
