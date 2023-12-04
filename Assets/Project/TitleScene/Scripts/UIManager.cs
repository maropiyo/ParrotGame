using UnityEngine;
using UnityEngine.UI;

class UIManager : MonoBehaviour
{
    // 表示名のテキスト
    public Text DisplayNameText;
    // 表示名の入力欄
    public InputField DisplayNameInputField;
    // ベストスコアのテキスト
    public Text BestScoreText;
    // ユーザー情報ポップアップ
    public GameObject UserInfoPopup;
    // モード選択ポップアップ
    public GameObject ModeSelectPopup;

    void Start()
    {
        // UIの更新
        UpdateUI();
    }

    // UIの更新
    public void UpdateUI()
    {
        // ローカルに保存されているデータを読み込む
        EasySaveManager.Instance.Load();

        // 表示名のテキストをセットする。
        SetDisplayNameText();

        // ベストスコアのテキストをセットする。
        SetBestScoreText();

        // 表示名の入力欄に表示名をセットする。
        SetDisplayNameInputField();
    }

    /// 表示名テキストをセットする。
    private void SetDisplayNameText()
    {
        // 表示名テキストをセットする。
        DisplayNameText.text = EasySaveManager.Instance.DisplayName;
    }

    /// ベストスコアのテキストをセットする。
    private void SetBestScoreText()
    {
        // ベストスコアのテキストをセットする。
        BestScoreText.text = "BEST: " + EasySaveManager.Instance.BestScore;
    }

    /// 表示名の入力欄に表示名をセットする。
    private void SetDisplayNameInputField()
    {
        // 表示名の入力欄に表示名をセットする。
        DisplayNameInputField.text = EasySaveManager.Instance.DisplayName;
    }

    /// 入力された表示名を保存する。
    public void SaveDisplayName()
    {
        // 入力された表示名を取得する。
        string displayName = DisplayNameInputField.text;
        // 表示名をローカルに保存する。
        EasySaveManager.Instance.SaveDisplayName(displayName);
        // 表示名をPlayFabに保存する。
        PlayFabController.Instance.UpdateAndGetDisplayName(displayName);
        // UIを更新する。
        UpdateUI();
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

    /// モード選択ポップアップを表示する
    public void ShowModeSelectPopup()
    {
        // モード選択ポップアップを表示する
        ModeSelectPopup.SetActive(true);
    }

    /// モード選択ポップアップを閉じる
    public void CloseModeSelectPopup()
    {
        // モード選択ポップアップを閉じる
        ModeSelectPopup.SetActive(false);
    }
}