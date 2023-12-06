using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    void Start()
    {
        // インタースティシャル広告をロードする。
        GoogleMobileAdsManager.Instance.LoadInterstitialAd();
    }

    // タイトル画面をロードする
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
