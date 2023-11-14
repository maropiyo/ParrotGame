using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面のSceneManager
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    // スタートボタンが押された時、ゲーム画面に遷移する
    public void ClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
