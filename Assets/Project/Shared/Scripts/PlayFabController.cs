using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System;

public class PlayFabController : MonoBehaviour
{
    // シングルトンパターンの実装
    public static PlayFabController Instance;
    // PlayFabId
    private string playFabId;

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

    private void OnEnable()
    {
        // PlayFabAuthServiceのログイン成功時のイベントハンドラーを登録
        PlayFabAuthService.OnLoginSuccess += PlayFabAuthService_OnLoginSuccess;
        // PlayFabAuthServiceのログイン失敗時のイベントハンドラーを登録
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
        // ログイン認証を開始する。
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }

    // ログイン成功時に呼ばれる
    private void PlayFabAuthService_OnLoginSuccess(LoginResult result)
    {
        Debug.Log("ログイン成功");
        // PlayFabIdを保存
        playFabId = result.PlayFabId;

        // ローカルの表示名をPlayFabに送信する。
        UpdateDisplayName(EasySaveManager.Instance.DisplayName);
        // ローカルのベストスコアをPlayFabに送信する。
        SubmitScore(EasySaveManager.Instance.BestScore);
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
    public void UpdateDisplayName(string displayName)
    {
        // 表示名の更新リクエストを作成する。
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = displayName
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
    }
    // 表示名の更新失敗時に呼ばれる
    private void OnUpdatedisplayNameFailure(PlayFabError error)
    {
        // エラー内容をログに出力
        Debug.LogError($"表示名の更新に失敗しました\n{error.GenerateErrorReport()}");
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

        // ランキングマネージャーを取得する。
        var rankingManager = GameObject.Find("RankingManager").GetComponent<RankingManager>();
        // すでに表示されているランキングノードを削除する。
        rankingManager.ClearRankingNodes();

        // ランキングを表示する。
        foreach (var item in result.Leaderboard)
        {
            // ランキングノードを生成する。
            rankingManager.GenerateRankingNode(
                (item.Position + 1).ToString(),
                item.DisplayName,
                item.StatValue.ToString()
            );
        }
    }

    // ランキング取得失敗時に呼ばれる
    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError($"ランキングの取得に失敗しました\n{error.GenerateErrorReport()}");
        // TODO: ランキングの取得に失敗した旨を表示する。
    }
}