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
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        }
        , OnSuccess => Debug.Log("PlayFab Login Success")
        , OnFailure => Debug.Log("PlayFab Login Failure"));
    }
}