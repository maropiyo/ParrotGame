using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面のSceneManager
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    // メニューポップアップ
    public GameObject menuPopup;
    // キャプチャするオブジェクト
    public GameObject captureObject;
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

        // スクリーンショットを撮影する
        CaptureScreenshot();

        // 2秒後にリザルト画面をロードする
        StartCoroutine(WaitAndLoadResultScene(1.5f));
    }

    // スクリーンショットを撮影する
    public void CaptureScreenshot()
    {
        // メインカメラ
        Camera camera = Camera.main;

        // カメラから見たスクリーンサイズ
        float wh = camera.orthographicSize * 2;
        float ww = wh * camera.aspect;
        // ターゲットサイズ
        float tw = captureObject.GetComponent<Renderer>().bounds.size.x;
        float th = captureObject.GetComponent<Renderer>().bounds.size.y;
        // 矩形サイズ
        float w = Screen.width * tw / ww;
        float h = Screen.height * th / wh;
        float x = camera.WorldToScreenPoint(captureObject.transform.position).x - w / 2;
        float y = camera.WorldToScreenPoint(captureObject.transform.position).y - h / 2;

        StartCoroutine(CaptureScreenshotCoroutine(x, y, w, h));
    }

    // スクリーンショットを撮影する
    IEnumerator CaptureScreenshotCoroutine(float x, float y, float w, float h)
    {
        // 1フレーム待つ
        yield return new WaitForEndOfFrame();
        Texture2D tex = new Texture2D((int)w, (int)h, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect((int)x, (int)y, (int)w, (int)h), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);
        string filename = "gameover_screenshot.png";
        string destination = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllBytes(destination, bytes);
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
