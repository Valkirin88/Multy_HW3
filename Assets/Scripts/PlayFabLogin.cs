using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabLogin : MonoBehaviour
{
    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            PlayFabSettings.staticSettings.TitleId = "B50D6";

        var request = new LoginWithCustomIDRequest
        {
            CustomId = "Player 1",
            CreateAccount = true
        };
        
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);

    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Complete Login");
    }

    private void OnLoginError(PlayFabError error)
    {
       var errorMessage = error.GenerateErrorReport();   
        Debug.Log(errorMessage);
    }
}
