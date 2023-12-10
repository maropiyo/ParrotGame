using UnityEngine;
using System.Collections;

public class ObjectPositionChecker : MonoBehaviour
{
    // ScoreManagerコンポーネント
    private ScoreManager scoreManager;
    // SoundEffectPlayerコンポーネント
    private SEPlayer soundEffectPlayer;
    // GameSceneManagerコンポーネント
    private GameSceneManager gameSceneManager;

    void Start()
    {
        // GameSceneManagerオブジェクトのGameSceneManagerコンポーネントを取得
        gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
        // チェックを有効にする
        enabled = true;
    }

    private void FixedUpdate()
    {
        CheckIfOutOfScreen();
    }

    private void CheckIfOutOfScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // 画面外に出たかどうかを判定
        if (enabled && (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height))
        {
            // チェックを無効にする
            enabled = false;

            // ゲームオーバー処理
            gameSceneManager.GameOver();
        }
    }
}
