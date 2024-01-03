using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        // ゲーム画面をロードする。
        SceneManager.LoadScene("GameScene");
    }

    // タイトル画面をロードする
    public void LoadTitleScene()
    {
        // タイトル画面をロードする。
        SceneManager.LoadScene("TitleScene");
    }

    // シェアをする
    public void Share()
    {
        // スクリーンショットを撮る
        ScreenCapture.CaptureScreenshot("share_screenshot.png");
        // シェアするテキスト
        string text = "インコゲームで" + EasySaveManager.Instance.CurrentScore + "点をとったよ！";
        // シェアする
        SunShineNativeShare.instance.ShareSingleFile(Application.persistentDataPath + "/share_screenshot.png", "png", text, "共有する");
    }

}
