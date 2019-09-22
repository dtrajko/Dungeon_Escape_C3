using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerGemCountText;
    public Image selectionImage;
    public int selectionImageOffsetY = 104;

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
}
