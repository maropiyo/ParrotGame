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

    // マメルリハの色
    public int MamerurihaColor { get; set; }
    // ボタンインコの色
    public int BotanColor { get; set; }
    // サザナミインコの色
    public int SazanamiColor { get; set; }
    // コザクラインコの色
    public int KozakuraColor { get; set; }
    // セキセイインコの色
    public int SekiseiColor { get; set; }
    // アキクサインコの色
    public int AkikusaColor { get; set; }
    // シロハラインコの色
    public int ShiroharaColor { get; set; }
    // オカメインコの色
    public int OkameColor { get; set; }
    // モモイロインコの色
    public int MomoiroColor { get; set; }
    // オハナインコの色
    public int OhanaColor { get; set; }
    // コンゴウインコの色
    public int KongoColor { get; set; }


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
        // 全てのインコの色をロードする。
        LoadAllParrotColor();
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

    // 全てのインコの色をロードする。
    public void LoadAllParrotColor()
    {
        // マメルリハの色をロードする。
        LoadMamerurihaColor();
        // ボタンインコの色をロードする。
        LoadBotanColor();
        // サザナミインコの色をロードする。
        LoadSazanamiColor();
        // コザクラインコの色をロードする。
        LoadKozakuraColor();
        // セキセイインコの色をロードする。
        LoadSekiseiColor();
        // アキクサインコの色をロードする。
        LoadAkikusaColor();
        // シロハラインコの色をロードする。
        LoadShiroharaColor();
        // オカメインコの色をロードする。
        LoadOkameColor();
        // モモイロインコの色をロードする。
        LoadMomoiroColor();
        // オハナインコの色をロードする。
        LoadOhanaColor();
        // コンゴウインコの色をロードする。
        LoadKongoColor();
    }

    // マメルリハの色をセーブする。
    public void SaveMamerurihaColor(int mamerurihaColor)
    {
        // マメルリハの色をセーブする。
        ES3.Save("MamerurihaColor", mamerurihaColor);

        // マメルリハの色をロードする。
        LoadMamerurihaColor();
    }

    // マメルリハの色をロードする。
    public void LoadMamerurihaColor()
    {
        // マメルリハの色をロードする。
        MamerurihaColor = ES3.Load<int>("MamerurihaColor", defaultValue: 0);
    }

    // ボタンインコの色をセーブする。
    public void SaveBotanColor(int botanColor)
    {
        // ボタンインコの色をセーブする。
        ES3.Save("BotanColor", botanColor);

        // ボタンインコの色をロードする。
        LoadBotanColor();
    }

    // ボタンインコの色をロードする。
    public void LoadBotanColor()
    {
        // ボタンインコの色をロードする。
        BotanColor = ES3.Load<int>("BotanColor", defaultValue: 0);
    }

    // サザナミインコの色をセーブする。
    public void SaveSazanamiColor(int sazanamiColor)
    {
        // サザナミインコの色をセーブする。
        ES3.Save("SazanamiColor", sazanamiColor);

        // サザナミインコの色をロードする。
        LoadSazanamiColor();
    }

    // サザナミインコの色をロードする。
    public void LoadSazanamiColor()
    {
        // サザナミインコの色をロードする。
        SazanamiColor = ES3.Load<int>("SazanamiColor", defaultValue: 0);
    }

    // コザクラインコの色をセーブする。
    public void SaveKozakuraColor(int kozakuraColor)
    {
        // コザクラインコの色をセーブする。
        ES3.Save("KozakuraColor", kozakuraColor);

        // コザクラインコの色をロードする。
        LoadKozakuraColor();
    }

    // コザクラインコの色をロードする。
    public void LoadKozakuraColor()
    {
        // コザクラインコの色をロードする。
        KozakuraColor = ES3.Load<int>("KozakuraColor", defaultValue: 0);
    }

    // セキセイインコの色をセーブする。
    public void SaveSekiseiColor(int sekiseiColor)
    {
        // セキセイインコの色をセーブする。
        ES3.Save("SekiseiColor", sekiseiColor);

        // セキセイインコの色をロードする。
        LoadSekiseiColor();
    }

    // セキセイインコの色をロードする。
    public void LoadSekiseiColor()
    {
        // セキセイインコの色をロードする。
        SekiseiColor = ES3.Load<int>("SekiseiColor", defaultValue: 0);
    }

    // アキクサインコの色をセーブする。
    public void SaveAkikusaColor(int akikusaColor)
    {
        // アキクサインコの色をセーブする。
        ES3.Save("AkikusaColor", akikusaColor);

        // アキクサインコの色をロードする。
        LoadAkikusaColor();
    }

    // アキクサインコの色をロードする。
    public void LoadAkikusaColor()
    {
        // アキクサインコの色をロードする。
        AkikusaColor = ES3.Load<int>("AkikusaColor", defaultValue: 0);
    }

    // シロハラインコの色をセーブする。
    public void SaveShiroharaColor(int shiroharaColor)
    {
        // シロハラインコの色をセーブする。
        ES3.Save("ShiroharaColor", shiroharaColor);

        // シロハラインコの色をロードする。
        LoadShiroharaColor();
    }

    // シロハラインコの色をロードする。
    public void LoadShiroharaColor()
    {
        // シロハラインコの色をロードする。
        ShiroharaColor = ES3.Load<int>("ShiroharaColor", defaultValue: 0);
    }

    // オカメインコの色をセーブする。
    public void SaveOkameColor(int okameColor)
    {
        // オカメインコの色をセーブする。
        ES3.Save("OkameColor", okameColor);

        // オカメインコの色をロードする。
        LoadOkameColor();
    }

    // オカメインコの色をロードする。
    public void LoadOkameColor()
    {
        // オカメインコの色をロードする。
        OkameColor = ES3.Load<int>("OkameColor", defaultValue: 0);
    }

    // モモイロインコの色をセーブする。
    public void SaveMomoiroColor(int momoiroColor)
    {
        // モモイロインコの色をセーブする。
        ES3.Save("MomoiroColor", momoiroColor);

        // モモイロインコの色をロードする。
        LoadMomoiroColor();
    }

    // モモイロインコの色をロードする。
    public void LoadMomoiroColor()
    {
        // モモイロインコの色をロードする。
        MomoiroColor = ES3.Load<int>("MomoiroColor", defaultValue: 0);
    }

    // オオハナインコの色をセーブする。
    public void SaveOhanaColor(int ohanaColor)
    {
        // オハナインコの色をセーブする。
        ES3.Save("OhanaColor", ohanaColor);

        // オハナインコの色をロードする。
        LoadOhanaColor();
    }

    // オオハナインコの色をロードする。
    public void LoadOhanaColor()
    {
        // オハナインコの色をロードする。
        OhanaColor = ES3.Load<int>("OhanaColor", defaultValue: 0);
    }

    // コンゴウインコの色をセーブする。
    public void SaveKongoColor(int kongoColor)
    {
        // コンゴウインコの色をセーブする。
        ES3.Save("KongoColor", kongoColor);

        // コンゴウインコの色をロードする。
        LoadKongoColor();
    }

    // コンゴウインコの色をロードする。
    public void LoadKongoColor()
    {
        // コンゴウインコの色をロードする。
        KongoColor = ES3.Load<int>("KongoColor", defaultValue: 0);
    }
}