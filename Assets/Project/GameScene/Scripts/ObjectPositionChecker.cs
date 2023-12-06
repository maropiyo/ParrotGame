using UnityEngine;
using System.Collections;

public class ObjectPositionChecker : MonoBehaviour
{
    // ScoreManagerコンポーネント
    private ScoreManager scoreManager;
    // SoundEffectPlayerコンポーネント
    private SoundEffectPlayer soundEffectPlayer;
    // GameSceneManagerコンポーネント
    private GameSceneManager gameSceneManager;

    void Start()
    {
        enabled = true;
        // ScoreManagerオブジェクトのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // SoundEffectManagerオブジェクトのSoundEffectPlayerコンポーネントを取得
        soundEffectPlayer = GameObject.Find("SoundEffectManager").GetComponent<SoundEffectPlayer>();
        // GameSceneManagerオブジェクトのGameSceneManagerコンポーネントを取得
        gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
    }

    private void FixedUpdate()
    {
        CheckIfOutOfScreen();
    }

    private void CheckIfOutOfScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // 画面外に出たかどうかを判定
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            // 一回だけ処理を行う
            enabled = false;
            // プレイヤーの動きを止める
            GameObject.Find("Player").GetComponent<PlayerMover>().canMove = false;
            // ベストスコアを保存
            scoreManager.SaveBestScore();
            StartCoroutine(PauseAndLoadCoroutine());
        }
        else
        {
            // 画面内にある場合は処理を継続
            enabled = true;
        }
    }


    IEnumerator PauseAndLoadCoroutine()
    {
        // 動きを停止
        Time.timeScale = 0;

        // 一定時間待つ
        yield return new WaitForSecondsRealtime(2.0f);


        // インタースティシャル広告を表示する
        GoogleMobileAdsManager.Instance.ShowInterstitialAd();

        // ゲームの時間を元に戻す
        Time.timeScale = 1f;

        // タイトルシーンに切り替える
        gameSceneManager.LoadTitleScene();
    }
}
