using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面のSceneManager
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
