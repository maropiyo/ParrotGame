using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
    // シーンコントローラー
    GameObject sceneController = GameObject.Find("SceneController");

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
    /// ゲームモードをSlipに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectSlipMode()
    {
        // ゲームモードをSlipに設定する。
        EasySaveManager.Instance.SaveGameMode("Slip");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }

    /// <summary>
    /// ゲームモードをJumpに設定してGameSceneに遷移する。
    /// </summary>
    public void SelectJumpMode()
    {
        // ゲームモードをJumpに設定する。
        EasySaveManager.Instance.SaveGameMode("Jump");
        // GameSceneに遷移する。
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }
}
