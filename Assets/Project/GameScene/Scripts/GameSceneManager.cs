using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    // メニューポップアップ
    public GameObject menuPopup;
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
        // ゲームを再開する。
        Resume();

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
        // ポーズする
        Pause();
        // プレイヤーの動きを止める
        GameObject.Find("Player").GetComponent<PlayerMover>().canMove = false;
        // スコアを保存
        scoreManager.SaveScore();

        // ゲームオーバー時のスプライトに変更する
        changeGameOverSprite();

        // 2秒後にリザルト画面をロードする
        StartCoroutine(WaitAndLoadResultScene(1.5f));
    }

    IEnumerator WaitAndLoadResultScene(float waitTime)
    {
        // 指定された時間待つ
        yield return new WaitForSecondsRealtime(waitTime);

        // ゲームを再開する。
        Resume();

        // リザルト画面をロード
        SceneManager.LoadScene("ResultScene");
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

    // ゲームオーバー時のスプライトに変更する
    private void changeGameOverSprite()
    {
        // タグのリスト
        string[] tagList = { "Mameruriha", "Botan", "Sazanami", "Kozakura", "Sekisei", "Akikusa", "Shirohara", "Okame", "Momoiro", "Ohana", "Kongo" };

        // タグのリストの数だけループする
        foreach (string tag in tagList)
        {
            // 画面上のタグがtagのオブジェクトがあればゲームオーバー時のスプライトに変更する
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<ParrotSpriteChanger>().ChangeGameOverSprite();
            }
        }
    }
}
