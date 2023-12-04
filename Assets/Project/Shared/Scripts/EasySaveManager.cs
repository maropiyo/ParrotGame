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
    // BGMの音量
    public float BgmVolume { get; private set; }
    // SEの音量
    public float SeVolume { get; private set; }
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

    void Start()
    {
        // セーブデータをロードする。
        Load();
    }

    // セーブデータをロードする。
    public void Load()
    {
        // ベストスコアをロードする。
        BestScore = ES3.Load(KEY_BEST_SCORE, 0);
        // BGMの音量をロードする。
        BgmVolume = ES3.Load(KEY_BGM_VOLUME, 1.0f);
        // SEの音量をロードする。
        SeVolume = ES3.Load(KEY_SE_VOLUME, 1.0f);
        // 表示名をロードする。
        DisplayName = ES3.Load<string>(KEY_DISPLAY_NAME, defaultValue: "名無しさん");
    }

    // べストスコアをセーブする。
    public void SaveBestScore(int bestScore)
    {
        // べストスコアをセーブする。
        ES3.Save(KEY_BEST_SCORE, bestScore);
    }

    // BGMの音量をセーブする。
    public void SaveBgmVolume(float bgmVolume)
    {
        // BGMの音量をセーブする。
        ES3.Save(KEY_BGM_VOLUME, bgmVolume);
    }

    // SEの音量をセーブする。
    public void SaveSeVolume(float seVolume)
    {
        // SEの音量をセーブする。
        ES3.Save(KEY_SE_VOLUME, seVolume);
    }

    // 表示名をセーブする。
    public void SaveDisplayName(string displayName)
    {
        // 表示名をセーブする。
        ES3.Save(KEY_DISPLAY_NAME, displayName);
    }

    // ゲームモードをセーブする。
    public void SaveGameMode(string gameMode)
    {
        // ゲームモードをセーブする。
        ES3.Save(KEY_GAME_MODE, gameMode);
    }
}
