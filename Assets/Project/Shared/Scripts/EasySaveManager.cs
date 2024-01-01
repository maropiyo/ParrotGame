using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySaveManager : MonoBehaviour
{
    // シングルトンパターンの実装
    public static EasySaveManager Instance;

    // セーブデータのキー
    const string KEY_CURRENT_SCORE = "CurrentScore";
    const string KEY_BEST_SCORE = "BestScore";
    const string KEY_BGM_VOLUME = "BgmVolume";
    const string KEY_SE_VOLUME = "SeVolume";
    const string KEY_DISPLAY_NAME = "DisplayName";
    const string KEY_GAME_MODE = "GameMode";

    // 現在のスコア
    public int CurrentScore { get; set; }
    // ベストスコア
    public int BestScore { get; private set; }
    // BGMの音量
    public float BgmVolume { get; set; }
    // SEの音量
    public float SeVolume { get; set; }
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
        // 現在のスコアをロードする。
        LoadCurrentScore();
        // ベストスコアをロードする。
        LoadBestScore();
        // 表示名をロードする。
        LoadDisplayName();
        // BGMの音量をロードする。
        LoadBgmVolume();
        // SEの音量をロードする。
        LoadSeVolume();
        // ゲームモードをロードする。
        LoadGameMode();
    }

    // 現在のスコアをセーブする。
    public void SaveCurrentScore(int currentScore)
    {
        // 現在のスコアをセーブする。
        ES3.Save(KEY_CURRENT_SCORE, currentScore);

        // 現在のスコアをロードする。
        LoadCurrentScore();
    }

    // 現在のスコアをロードする。
    public void LoadCurrentScore()
    {
        // 現在のスコアをロードする。
        CurrentScore = ES3.Load<int>(KEY_CURRENT_SCORE, defaultValue: 0);
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

    // BGMの音量をセーブする。
    public void SaveBgmVolume(float bgmVolume)
    {
        // BGMの音量をセーブする。
        ES3.Save(KEY_BGM_VOLUME, bgmVolume);

        // BGMの音量をロードする。
        LoadBgmVolume();
    }

    // BGMの音量をロードする。
    public void LoadBgmVolume()
    {
        // BGMの音量をロードする。
        BgmVolume = ES3.Load<float>(KEY_BGM_VOLUME, defaultValue: 1.0f);
    }

    // SEの音量をセーブする。
    public void SaveSeVolume(float seVolume)
    {
        // SEの音量をセーブする。
        ES3.Save(KEY_SE_VOLUME, seVolume);

        // SEの音量をロードする。
        LoadSeVolume();
    }

    // SEの音量をロードする。
    public void LoadSeVolume()
    {
        // SEの音量をロードする。
        SeVolume = ES3.Load<float>(KEY_SE_VOLUME, defaultValue: 1.0f);
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

        // ゲームモードをロードする。
        LoadGameMode();
    }

    // ゲームモードをロードする。
    public void LoadGameMode()
    {
        // ゲームモードをロードする。
        GameMode = ES3.Load<string>(KEY_GAME_MODE, defaultValue: "Sun");
    }

    // マメルリハの色をセーブする。
    public void SaveMamerurihaColor(string mamerurihaColor)
    {
        // マメルリハの色をセーブする。
        ES3.Save("MamerurihaColor", mamerurihaColor);
    }

    // マメルリハの色をロードする。
    public string LoadMamerurihaColor()
    {
        // マメルリハの色をロードする。
        return ES3.Load<string>("MamerurihaColor", defaultValue: "Green");
    }

    // ボタンインコの色をセーブする。
    public void SaveBotanColor(string botanColor)
    {
        // ボタンインコの色をセーブする。
        ES3.Save("BotanColor", botanColor);
    }

    // ボタンインコの色をロードする。
    public string LoadBotanColor()
    {
        // ボタンインコの色をロードする。
        return ES3.Load<string>("BotanColor", defaultValue: "Blue");
    }

    // サザナミインコの色をセーブする。
    public void SaveSazanamiColor(string sazanamiColor)
    {
        // サザナミインコの色をセーブする。
        ES3.Save("SazanamiColor", sazanamiColor);
    }

    // サザナミインコの色をロードする。
    public string LoadSazanamiColor()
    {
        // サザナミインコの色をロードする。
        return ES3.Load<string>("SazanamiColor", defaultValue: "Blue");
    }

    // セキセイインコの色をセーブする。
    public void SaveSekiseiColor(string sekiseiColor)
    {
        // セキセイインコの色をセーブする。
        ES3.Save("SekiseiColor", sekiseiColor);
    }

    // セキセイインコの色をロードする。
    public string LoadSekiseiColor()
    {
        // セキセイインコの色をロードする。
        return ES3.Load<string>("SekiseiColor", defaultValue: "Blue");
    }
}
