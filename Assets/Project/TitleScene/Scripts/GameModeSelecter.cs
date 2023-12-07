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
    /// ゲームモードをJumpに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectJumpMode()
    {
        // ゲームモードをSlipに設定する。
        EasySaveManager.Instance.SaveGameMode("Jump");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }

    /// <summary>
    /// ゲームモードをSuperJumpに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectSuperJumpMode()
    {
        // ゲームモードをSuperJumpに設定する。
        EasySaveManager.Instance.SaveGameMode("SuperJump");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }
}
