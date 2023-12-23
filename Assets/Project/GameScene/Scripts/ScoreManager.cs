using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // インコのタグと点数の対応表
    private Dictionary<string, int> ParrotScores = new Dictionary<string, int>
    {
        {"Mameruriha", 1},
        {"Botan", 3},
        {"Sazanami", 6},
        {"Kozakura", 10},
        {"Lutino", 15},
        {"Sekisei", 21},
        {"Shirohara", 28},
        {"Okame", 36},
        {"Momoiro", 45},
        {"Ohana", 55},
        {"Kongo", 66}
    };

    // スコアを表示するテキストコンポーネント
    public Text currentScoreText;
    // ベストスコアを表示するテキストコンポーネント
    public Text bestScoreText;
    // 現在のスコア
    private int currentScore = 0;
    // ベストスコア
    private int bestScore = 0;

    void Start()
    {
        // ゲーム開始時のベストスコアを取得する。
        bestScore = ES3.Load<int>("BestScore", defaultValue: 0);
        bestScoreText.text = bestScore.ToString();
    }

    void Update()
    {
        // スコアを更新する。
        UpdateScore();
        // ベストスコアを更新する。
        UpdateBestScore();
    }

    /// <summary>
    /// オブジェクトのタグに応じたスコアを加算する。
    /// </summary>
    public void addScore(string tag)
    {
        // スコアを加算
        currentScore += ParrotScores[tag];
    }

    /// <summary>
    /// スコアを保存する。
    /// </summary>
    public void SaveScore()
    {
        // 現在のスコアを保存する。
        EasySaveManager.Instance.SaveCurrentScore(currentScore);
        // ベストスコアを保存する。
        EasySaveManager.Instance.SaveBestScore(bestScore);
        // ベストスコアをPlayFabに送信する。
        PlayFabController.Instance.SubmitScore(bestScore);
    }

    /// <summary>
    /// ベストスコアをUIに反映させる。
    /// </summary>
    private void UpdateBestScore()
    {
        // 現在のスコアがベストスコアを上回った場合、ベストスコアを上書きする。
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
        }
        // UIに反映させる。
        bestScoreText.text = bestScore.ToString();
    }

    /// <summary>
    /// 現在のスコアをUIに反映させる。
    /// </summary>
    private void UpdateScore()
    {
        // UIに反映させる。
        currentScoreText.text = currentScore.ToString();
    }
}