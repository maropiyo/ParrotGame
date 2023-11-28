using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    // タイトル画面をロードする
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");

    }
}
