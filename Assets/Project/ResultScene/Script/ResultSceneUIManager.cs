using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // スコアを表示するテキスト
    public Text scoreText;

    void Start()
    {
        // スコアを表示する
        scoreText.text = EasySaveManager.Instance.CurrentScore.ToString();
    }
}
