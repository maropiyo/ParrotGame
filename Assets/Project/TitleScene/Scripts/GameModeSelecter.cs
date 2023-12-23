using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
    // シーンコントローラー
    public GameObject sceneController;

    /// <summary>
    /// ゲームモードをNormalに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectNormalMode()
    {
        // ゲームモードをNormalに設定する。
        EasySaveManager.Instance.SaveGameMode("Normal");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }

    /// <summary>
    /// ゲームモードをHardに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectJumpMode()
    {
        // ゲームモードをHardに設定する。
        EasySaveManager.Instance.SaveGameMode("Hard");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }
}
