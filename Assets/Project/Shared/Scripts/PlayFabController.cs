using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.SocialPlatforms.Impl;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController Instance;
    public bool DontDestroyEnabled = true;
    // 表示名
    [HideInInspector] public string DisplayName { get; private set; }

    /* UIパーツ */
    // 表示名テキスト
    [SerializeField] Text DisplayNameText;
    // 表示名入力欄
    [SerializeField] InputField DisplayNameInputField;

    void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;

            if (DontDestroyEnabled)
            {
                // Sceneを遷移してもオブジェクトが消えないようにする
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // イベントハンドラーの登録
    private void OnEnable()
    {
        // ログイン成功時のイベントハンドラーを登録
        PlayFabAuthService.OnLoginSuccess += PlayFabAuthService_OnLoginSuccess;
        // ログイン失敗時のイベントハンドラーを登録
        PlayFabAuthService.OnPlayFabError += PlayFabAuthService_OnPlayFabError;
    }
    private void OnDisable()
    {
        // ログイン成功時のイベントハンドラーを解除
        PlayFabAuthService.OnLoginSuccess -= PlayFabAuthService_OnLoginSuccess;
        // ログイン失敗時のイベントハンドラーを解除
        PlayFabAuthService.OnPlayFabError -= PlayFabAuthService_OnPlayFabError;
    }

    void Start()
    {
        // 匿名認証を行う。
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }

    // ログイン成功時に呼ばれる
    private void PlayFabAuthService_OnLoginSuccess(LoginResult result)
    {
        Debug.Log("ログイン成功");
        // 表示名を取得してUIに表示する。
        GetDisplayName(result.PlayFabId);
        // ベストスコアをPlayFabに送信する。(オフラインでスコアを更新した時などに反映される)
        SubmitScore(ES3.Load<int>("BestScore", defaultValue: 0));
    }
    // ログイン失敗時に呼ばれる
    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("ログイン失敗");
        Debug.Log(error.ToString());
    }

    /// <summary>
    /// 表示名を更新する。
    /// InputFieldのOnEndEditから呼び出す。
    /// </summary>
    public void UpdateDisplayName()
    {
        // 表示名の更新リクエストを作成する。
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = DisplayNameInputField.text
        };

        // 表示名の更新を開始する。
        Debug.Log($"表示名の更新を開始します");
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            request,
            OnUpdateDisplayNameSuccess,
            OnUpdatedisplayNameFailure
        );
    }
    // 表示名の更新成功時に呼ばれる
    private void OnUpdateDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log($"表示名の更新に成功しました。DisplayName: {result.DisplayName}");
        DisplayName = result.DisplayName;
        // 表示名を保存する。
        ES3.Save<string>("DisplayName", DisplayName);
        GameObject.Find("SceneController").GetComponent<TitleSceneManager>().ShowDisplayName();
    }
    // 表示名の更新失敗時に呼ばれる
    private void OnUpdatedisplayNameFailure(PlayFabError error)
    {
        // エラー内容をログに出力
        Debug.LogError($"表示名の更新に失敗しました\n{error.GenerateErrorReport()}");
    }

    /// <summary>
    /// 表示名を取得する。
    /// </summary>
    /// <param name="playFabId"></param>
    public void GetDisplayName(string playFabId)
    {
        // リクエストを作成する。
        var request = new GetPlayerProfileRequest
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true
            }
        };
        // 表示名の取得を開始する。
        Debug.Log($"表示名の取得を開始します");
        PlayFabClientAPI.GetPlayerProfile(
            request,
            OnGetDisplayNameSuccess,
            OnGetDisplayNameFailure
        );
    }
    // 表示名の取得成功時に呼ばれる
    private void OnGetDisplayNameSuccess(GetPlayerProfileResult result)
    {
        Debug.Log($"表示名の取得に成功しました。DisplayName: {result.PlayerProfile.DisplayName}");
        DisplayName = result.PlayerProfile.DisplayName;
        // 表示名を保存する。
        ES3.Save<string>("DisplayName", DisplayName);
        GameObject.Find("SceneController").GetComponent<TitleSceneManager>().ShowDisplayName();
    }
    // 表示名の取得失敗時に呼ばれる
    private void OnGetDisplayNameFailure(PlayFabError error)
    {
        Debug.LogError($"表示名の取得に失敗しました\n{error.GenerateErrorReport()}");
    }

    /// <summary>
    /// スコアを送信する。
    /// </summary>
    /// <param name="playerScore"></param>
    public void SubmitScore(int playerScore)
    {
        // リクエストを作成する。
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScoreRanking",
                    Value = playerScore
                }
            }
        };

        // スコアの送信を開始する。
        Debug.Log($"スコアの送信を開始します");
        PlayFabClientAPI.UpdatePlayerStatistics(
            request,
            OnSubmitScoreSuccess,
            OnSubmitScoreFailure
        );
    }
    // スコア送信成功時に呼ばれる
    private void OnSubmitScoreSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"スコアの送信に成功しました");
    }
    // スコア送信失敗時に呼ばれる
    private void OnSubmitScoreFailure(PlayFabError error)
    {
        Debug.LogError($"スコアの送信に失敗しました\n{error.GenerateErrorReport()}");
    }

    /// <summary>
    /// ランキングを取得する。
    /// </summary>
    public void GetLeaderboard()
    {

        // リクエストを作成する。
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScoreRanking",
        };
        PlayFabClientAPI.GetLeaderboard(
            request,
            OnGetLeaderboardSuccess,
            OnGetLeaderboardFailure
            );
    }
    // ランキング取得成功時に呼ばれる
    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log($"ランキングの取得に成功しました");
        // ランキングをログに出力する。
        foreach (var item in result.Leaderboard)
        {
            Debug.Log($"DisplayName: {item.DisplayName}, Score: {item.StatValue}");
        }
    }
    // ランキング取得失敗時に呼ばれる
    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError($"ランキングの取得に失敗しました\n{error.GenerateErrorReport()}");
    }
}