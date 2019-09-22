using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerGemCountText;
    public Image selectionImage;
    private float selectionImageLocalPositionY;

    private static UIManager _instance;

    private void Awake() {
        _instance = this;
        selectionImageLocalPositionY = selectionImage.transform.localPosition.y;
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
        float selImageLocalPosY = selectionImageLocalPositionY;
        float selImageAnchorPosY = 0;
        switch (index)
        {
            case 0:
                selImageLocalPosY = selectionImageLocalPositionY + 104;
                selImageAnchorPosY = +104;
                break;
            case 1:
                selImageLocalPosY = selectionImageLocalPositionY;
                selImageAnchorPosY = 0;
                break;
            case 2:
                selImageLocalPosY = selectionImageLocalPositionY - 104;
                selImageAnchorPosY = -104;
                break;
        }
        // selectionImage.transform.localPosition = new Vector3(
        //     selectionImage.transform.localPosition.x,
        //     selImageLocalPosY,
        //     selectionImage.transform.localPosition.z
        // );
        selectionImage.rectTransform.anchoredPosition = new Vector2(
            selectionImage.rectTransform.anchoredPosition.x,
            selImageAnchorPosY
        );
    }
}
