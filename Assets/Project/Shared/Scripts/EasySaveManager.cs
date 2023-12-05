using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySaveManager : MonoBehaviour
{
    // シングルトンパターンの実装
    public static EasySaveManager Instance;

    // セーブデータのキー
    const string KEY_BEST_SCORE = "BestScore";
    const string KEY_BGM_VOLUME = "BgmVolume";
    const string KEY_SE_VOLUME = "SeVolume";
    const string KEY_DISPLAY_NAME = "DisplayName";
    const string KEY_GAME_MODE = "GameMode";

    // ベストスコア
    public int BestScore { get; private set; }
    // 表示名
    public string DisplayName { get; private set; }
    // ゲームモード
    public string GameMode { get; set; }


    void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // セーブデータをロードする。
    public void Load()
    {
        // ベストスコアをロードする。
        LoadBestScore();
        // 表示名をロードする。
        LoadDisplayName();
        // ゲームモードをロードする。
        LoadGameMode();
    }

    // べストスコアをセーブする。
    public void SaveBestScore(int bestScore)
    {
        // べストスコアをセーブする。
        ES3.Save(KEY_BEST_SCORE, bestScore);

        // ベストスコアをロードする。
        LoadBestScore();
    }

    // ベストスコアをロードする。
    public void LoadBestScore()
    {
        // ベストスコアをロードする。
        BestScore = ES3.Load<int>(KEY_BEST_SCORE, defaultValue: 0);
    }

    // 表示名をセーブする。
    public void SaveDisplayName(string displayName)
    {
        // 表示名をセーブする。
        ES3.Save(KEY_DISPLAY_NAME, displayName);

        // 表示名をロードする。
        LoadDisplayName();
    }

    // 表示名をロードする。
    public void LoadDisplayName()
    {
        // 表示名をロードする。
        DisplayName = ES3.Load<string>(KEY_DISPLAY_NAME, defaultValue: "名無しのインコ");
    }

    // ゲームモードをセーブする。
    public void SaveGameMode(string gameMode)
    {
        // ゲームモードをセーブする。
        ES3.Save(KEY_GAME_MODE, gameMode);
    }

    // ゲームモードをロードする。
    public void LoadGameMode()
    {
        // ゲームモードをロードする。
        GameMode = ES3.Load<string>(KEY_GAME_MODE, defaultValue: "Normal");
    }
}
