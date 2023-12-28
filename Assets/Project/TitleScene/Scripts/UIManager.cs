using UnityEngine;
using UnityEngine.UI;

class UIManager : MonoBehaviour
{
    // 表示名のテキスト
    public Text DisplayNameText;
    // 表示名の入力欄
    public InputField DisplayNameInputField;
    // BGMの音量のスライダー
    public Slider BgmVolumeSlider;
    // SEの音量のスライダー
    public Slider SeVolumeSlider;
    // 設定ポップアップ
    public GameObject SettingPopup;
    // ユーザー情報ポップアップ
    public GameObject UserInfoPopup;

    void Start()
    {
        // ローカルに保存されているデータを読み込む
        EasySaveManager.Instance.Load();

        // UIを更新する。
        UpdateUI();
    }

    // UIを更新する。
    public void UpdateUI()
    {
        // 表示名のテキストをセットする。
        SetDisplayNameText();

        // 表示名の入力欄に表示名をセットする。
        SetDisplayNameInputField();

        // BGMの音量スライダーの値をセットする。
        SetBgmVolumeSlider();

        // SEの音量スライダーの値をセットする。
        SetSeVolumeSlider();
    }

    /// 表示名テキストをセットする。
    private void SetDisplayNameText()
    {
        // 表示名テキストをセットする。
        DisplayNameText.text = EasySaveManager.Instance.DisplayName;
    }

    /// 表示名の入力欄に表示名をセットする。
    private void SetDisplayNameInputField()
    {
        // 表示名の入力欄に表示名をセットする。
        DisplayNameInputField.text = EasySaveManager.Instance.DisplayName;
    }

    /// 入力された表示名を保存する。
    public void SaveInputDisplayName()
    {
        // 入力された表示名を取得する。
        string displayName = DisplayNameInputField.text;
        // 表示名をローカルに保存する。
        EasySaveManager.Instance.SaveDisplayName(displayName);
        // 表示名テキストを更新する。
        SetDisplayNameText();
        // ユーザー情報ポップアップを閉じる。
        CloseUserInfoPopup();
        // 表示名をPlayFabに保存する。
        PlayFabController.Instance.UpdateDisplayName(displayName);
    }

    /// BGMの音量スライダーの値をセットする。
    private void SetBgmVolumeSlider()
    {
        // BGMの音量スライダーの値をセットする。
        BgmVolumeSlider.value = EasySaveManager.Instance.BgmVolume;
    }

    /// BGMの音量スライダーの値を保存する。
    public void SaveBgmVolumeSlider()
    {
        // BGMの音量スライダーの値を保存する。
        EasySaveManager.Instance.SaveBgmVolume(BgmVolumeSlider.value);

        // BGMの音量を更新する。
        BGMPlayer.Instance.UpdateBgmVolume();
    }

    /// SEの音量スライダーの値をセットする。
    private void SetSeVolumeSlider()
    {
        // SEの音量スライダーの値をセットする。
        SeVolumeSlider.value = EasySaveManager.Instance.SeVolume;
    }

    /// SEの音量スライダーの値を保存する。
    public void SaveSeVolumeSlider()
    {
        // SEの音量スライダーの値を保存する。
        EasySaveManager.Instance.SaveSeVolume(SeVolumeSlider.value);

        // SEの音量を更新する。
        SEPlayer.Instance.UpdateSeVolume();
    }

    /// 設定ポップアップを表示する
    public void ShowSettingPopup()
    {
        // 設定ポップアップを表示する
        SettingPopup.SetActive(true);
    }

    /// 設定ポップアップを閉じる
    public void CloseSettingPopup()
    {
        // 設定ポップアップを閉じる
        SettingPopup.SetActive(false);
    }

    /// ユーザー情報ポップアップを表示する
    public void ShowUserInfoPopup()
    {
        // 表示名の入力欄に表示名をセットする。
        SetDisplayNameInputField();
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