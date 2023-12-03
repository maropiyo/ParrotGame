using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabController : MonoBehaviour
{
    void Start()
    {
        // PlayFabにログインする。
        LoginToPlayFab();
    }

    /// <summary>
    /// PlayFabにログインする。
    /// </summary>
    void LoginToPlayFab()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest
            {
                CustomId = System.Guid.NewGuid().ToString("N"),
                // アカウントが存在しない場合は新規作成する。
                CreateAccount = true,
            }
        , OnSuccess => Debug.Log("PlayFab Login Success")
        , OnFailure => Debug.Log("PlayFab Login Failure"));
    }
}