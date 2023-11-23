using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // インコと点数の対応表
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
    // 現在のスコア
    private int currentScore = 0;


    void Update()
    {
        // スコアの変化を監視し、UIに反映
        UpdateScoreUI();
    }

    public void addScore(string tag)
    {
        // スコアを加算
        currentScore += ParrotScores[tag];
    }

    private void UpdateScoreUI()
    {
        currentScoreText.text = currentScore.ToString();
    }
}