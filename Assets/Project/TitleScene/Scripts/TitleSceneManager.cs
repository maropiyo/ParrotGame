using PlayFab;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// タイトル画面のSceneManager
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    // ユーザー情報ポップアップ
    [SerializeField] private GameObject UserInfoPopup;

    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// ユーザー情報ポップアップを表示する
    public void ShowUserInfoPopup()
    {
        // ユーザー情報ポップアップを表示する
        UserInfoPopup.SetActive(true);
    }

    /// ユーザー情報ポップアップを閉じる
    public void CloseUserInfoPopup()
    {
        // 表示名を更新する
        PlayFabAuthenticationContext player = PlayFabSettings.staticPlayer;
        PlayFabController.Instance.GetDisplayName(player.PlayFabId);
        // ユーザー情報ポップアップを閉じる
        UserInfoPopup.SetActive(false);
    }
}
