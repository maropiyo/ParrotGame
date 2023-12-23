using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    // メニューポップアップ
    public GameObject menuPopup;
    // リザルトポップアップ
    public GameObject resultPopup;
    // ScoreManagerコンポーネント
    private ScoreManager scoreManager;
    // SoundEffectPlayerコンポーネント
    private SEPlayer soundEffectPlayer;
    // GameSceneManagerコンポーネント
    private GameSceneManager gameSceneManager;


    void Start()
    {
        // ScoreManagerオブジェクトのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        // ゲームを再開する。
        Resume();

        // インタースティシャル広告をロードする。
        // GoogleMobileAdsManager.Instance.LoadInterstitialAd();
    }

    // タイトル画面をロードする
    public void LoadTitleScene()
    {
        // タイトル画面をロードする。
        SceneManager.LoadScene("TitleScene");
    }

    // リザルト画面をロードする
    public void LoadResultScene()
    {
        // ゲーム画面をロードする。
        SceneManager.LoadScene("ResultScene");
    }

    // ゲームオーバー時の処理
    public void GameOver()
    {
        // プレイヤーの動きを止める
        GameObject.Find("Player").GetComponent<PlayerMover>().canMove = false;
        // スコアを保存
        scoreManager.SaveScore();

        // リザルト画面をロードする。
        LoadResultScene();
    }

    // メニューポップアップを表示する
    public void ShowMenuPopup()
    {
        // ゲームを一時停止する。
        Pause();

        // メニューポップアップを表示する。
        menuPopup.SetActive(true);
    }

    // メニューポップアップを閉じる
    public void CloseMenuPopup()
    {
        // ゲームを再開する。
        Resume();

        // メニューポップアップを非表示にする。
        menuPopup.SetActive(false);
    }

    // リザルトポップアップを表示する
    public void ShowResultPopup()
    {
        // ゲームを一時停止する。
        Pause();

        // リザルトポップアップを表示する。
        resultPopup.SetActive(true);
    }

    // リザルトポップアップを閉じる
    public void CloseResultPopup()
    {
        // ゲームを再開する。
        Resume();

        // リザルトポップアップを非表示にする。
        resultPopup.SetActive(false);
    }

    // ポーズする
    public void Pause()
    {
        // ゲームを一時停止する。
        Time.timeScale = 0;
    }

    // ポーズを解除する
    public void Resume()
    {
        // ゲームを再開する。
        Time.timeScale = 1;
    }

}
