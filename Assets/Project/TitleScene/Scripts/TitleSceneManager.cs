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
    // ベストスコアを表示するテキスト
    [SerializeField] Text BestScoreText;
    // ユーザー情報ポップアップ
    [SerializeField] private GameObject UserInfoPopup;

    void Start()
    {
        // すでにログインしている場合
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            // 表示名を表示する。
            ShowDisplayName();
        }

        // ベストスコアを表示する。
        BestScoreText.text = "最高: " + ES3.Load<int>("BestScore", defaultValue: 0);
    }

    // ゲーム画面をロードする
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 表示名を表示する
    public void ShowDisplayName()
    {
        string displayName = ES3.Load<string>("DisplayName", defaultValue: "名無し");
        // 表示名を更新する。
        DisplayNameInputField.text = displayName;
        // 表示名入力欄の文字列を更新する。
        DisplayNameText.text = displayName;
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
