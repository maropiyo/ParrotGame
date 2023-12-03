using PlayFab;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// タイトル画面のSceneManager
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    /* UIパーツ */
    // 表示名テキスト
    [SerializeField] Text DisplayNameText;
    // 表示名入力欄
    [SerializeField] InputField DisplayNameInputField;
    // ユーザー情報ポップアップ
    [SerializeField] private GameObject UserInfoPopup;

    void Start()
    {
        // すでにログインしている場合
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            // 表示名を取得する。
            PlayFabController.Instance.GetDisplayName(PlayFabSettings.staticPlayer.PlayFabId);
        }
    }

    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 表示名を更新する
    public void UpdateDisplayName(string displayName)
    {
        // 入力欄の文字列を表示名に設定する。
        DisplayNameText.text = displayName;
        // 表示名を更新する。
        DisplayNameInputField.text = displayName;
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
        // ユーザー情報ポップアップを閉じる
        UserInfoPopup.SetActive(false);
    }
}
