using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{

    [SerializeField]
    private Button _loginButton;
    [SerializeField]
    private TextMeshProUGUI _connectInfoText;

    private void Start()
    {
        _loginButton.onClick.AddListener(Connect);
    }


    private void Connect()
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
        _connectInfoText.text = "Complete Login";
        _connectInfoText.color = Color.green;
    }

    private void OnLoginError(PlayFabError error)
    {
       var errorMessage = error.GenerateErrorReport();   
        Debug.Log(errorMessage);
        _connectInfoText.text = errorMessage;
        _connectInfoText.color = Color.red;
    }
}
