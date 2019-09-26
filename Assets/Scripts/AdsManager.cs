using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public void ShowRewardedAd() {
        Debug.Log("Showing Rewarded Ad!");

        if (Advertisement.IsReady("rewardedVideo")) {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {
        switch (result) {
            case ShowResult.Finished:
                Debug.Log("Unity Reward Video Ad completed successfully!");
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.OpenShop(GameManager.Instance.Player.Diamonds);
                Debug.Log("Gamer rewarded with 100 Gems!");
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped the ad! No Gems for you!");
                break;
            case ShowResult.Failed:
                Debug.Log("The video ad failed, it must not have been ready.");
                break;
        }
    }
}
