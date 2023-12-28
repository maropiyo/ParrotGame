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
}
