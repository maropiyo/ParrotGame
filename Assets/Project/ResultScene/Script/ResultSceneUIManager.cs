using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // リザルト画面のタイトルテキスト
    public Text titleText;

    // スコアを表示するテキスト
    public Text scoreText;

    // ゲームオーバー時のスクリーンショットを表示するRawImage
    public RawImage gameOverImage;

    void Start()
    {
        // スコアを取得する
        int currentScore = EasySaveManager.Instance.CurrentScore;
        // ベストスコアを取得する
        int highScore = EasySaveManager.Instance.BestScore;


        // ベストスコアを更新した場合
        if (currentScore == highScore)
        {
            // タイトルテキストを「NEW RECORD」にする
            titleText.text = "NEW RECORD!!";
        }
        else
        {
            // タイトルテキストを「GAME OVER」にする
            titleText.text = "GAME OVER";
        }

        // スコアを表示する
        scoreText.text = currentScore.ToString();

        // スクリーンショットの読み込み
        byte[] image = File.ReadAllBytes(Application.persistentDataPath + "/gameover_screenshot.png");

        // Texture2D を作成して読み込み
        Texture2D texture2D = new Texture2D(0, 0);
        texture2D.LoadImage(image);

        // ゲームオーバー時のスクリーンショットを表示する
        gameOverImage.texture = texture2D;
    }
}
