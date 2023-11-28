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
        // ScoreManagerオブジェクトのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // SoundEffectManagerオブジェクトのSoundEffectPlayerコンポーネントを取得
        soundEffectPlayer = GameObject.Find("SoundEffectManager").GetComponent<SoundEffectPlayer>();
        // GameSceneManagerオブジェクトのGameSceneManagerコンポーネントを取得
        gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
    }

    private void Update()
    {
        CheckIfOutOfScreen();
    }

    private void CheckIfOutOfScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // 画面外に出たかどうかを判定
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            // ベストスコアを保存
            scoreManager.SaveBestScore();
            StartCoroutine(PauseAndLoadCoroutine());
        }
    }


    IEnumerator PauseAndLoadCoroutine()
    {
        // 動きを停止
        Time.timeScale = 0;

        // 一定時間待つ
        yield return new WaitForSecondsRealtime(2.0f);

        // ゲームの時間を元に戻す
        Time.timeScale = 1f;

        // タイトルシーンに切り替える
        gameSceneManager.LoadTitleScene();
    }
}
