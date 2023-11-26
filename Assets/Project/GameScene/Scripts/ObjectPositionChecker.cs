using UnityEngine;

public class ObjectPositionChecker : MonoBehaviour
{
    // ScoreManagerコンポーネント
    private ScoreManager scoreManager;
    // SoundManagerコンポーネント
    private SoundEffectPlayer soundEffectPlayer;
    // GameSceneManagerコンポーネント
    private GameSceneManager gameSceneManager;

    void Start()
    {
        // ScoreManagerオブジェクトのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // SoundManagerオブジェクトのSoundEffectPlayerコンポーネントを取得
        soundEffectPlayer = GameObject.Find("SoundManager").GetComponent<SoundEffectPlayer>();
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
        if (screenPosition.y < 0)
        {
            // ベストスコアを保存
            scoreManager.SaveBestScore();
            // タイトル画面に遷移
            gameSceneManager.LoadTitleScene();
        }
    }
}
