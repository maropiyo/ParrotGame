using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController Instance;
    public bool DontDestroyEnabled = true;
    // 情報を取得する際のパラメータ
    [SerializeField] GetPlayerCombinedInfoRequestParams InfoRequestParams;
    // ユーザー名
    [HideInInspector] public string UserName { get; private set; }

    // ユーザー名テキスト
    [SerializeField] Text UserNameText;


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
    private void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += PlayFabAuthService_OnPlayFabError;
    }

    private void OnDisable()
    {
        PlayFabAuthService.OnLoginSuccess -= PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError -= PlayFabAuthService_OnPlayFabError;
    }

    private void PlayFabAuthService_OnLoginSuccess(LoginResult result)
    {
        Debug.Log("ログイン成功");
        // ユーザー名を取得してUIに表示する。
        UserName = result.InfoResultPayload.UserData["Name"].Value;
        UserNameText.text = UserName;
    }
    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("ログイン失敗");
        Debug.Log(error.ToString());
    }
    void Start()
    {
        // InfoRequestParamsを初期化
        PlayFabAuthService.Instance.InfoRequestParams = InfoRequestParams;

        // 匿名認証を行う。
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }

    /// <summary>
    /// ユーザー名を設定する。
    /// </summary>
    /// <param name="displayName"></param>
    public void SetPlayerDisplayName(string displayName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = displayName
            },
            result =>
            {
                Debug.Log("Set display name was succeeded.");

            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }

    /// <summary>
    /// スコアを送信する。
    /// </summary>
    /// <param name="playerScore"></param>
    public void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScoreRanking",
                    Value = playerScore
                }
            }
        }, result =>
        {
            Debug.Log($"スコア {playerScore} 送信完了！");
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }

    /// <summary>
    /// ランキングを取得する。
    /// </summary>
    public void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "HighScoreRanking"
        }, result =>
        {
            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName;
                if (displayName == null)
                {
                    displayName = "NoName";
                }
                Debug.Log($"{item.Position + 1}位:{displayName} " + $"スコア {item.StatValue}");
            }
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
}