using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabAccountManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleLabel;

    private void Start()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccount, OnError);
    }

    private void OnGetAccount(GetAccountInfoResult result)
    {
        _titleLabel.text = $"Playfab id: {result.AccountInfo.PlayFabId}, \nCreated date: {result.AccountInfo.Created},\nTitle: {result.AccountInfo.TitleInfo}";

    }

    private void OnError(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.Log(errorMessage);
    }
}
