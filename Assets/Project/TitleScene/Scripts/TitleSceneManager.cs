using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面のSceneManager
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    // ゲームモード選択パネル
    public GameObject gameModeSelectPanel;

    void Start()
    {
        gameModeSelectPanel.SetActive(false);
    }

    // ゲームモード選択パネルの表示を切り替える
    public void SwitchGameModeSelectPanelDisplay()
    {
        gameModeSelectPanel.SetActive(!gameModeSelectPanel.activeSelf);
    }

    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
