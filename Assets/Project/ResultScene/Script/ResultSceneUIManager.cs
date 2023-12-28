using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // リザルト画面のタイトルテキスト
    public Text titleText;

    // スコアを表示するテキスト
    public Text scoreText;

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
    }
}
