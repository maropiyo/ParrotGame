using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    // タイトル画面をロードする
    // TODO: GameOver画面を作ったらそっちに切り替える。
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
