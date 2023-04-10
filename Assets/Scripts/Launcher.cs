using UnityEngine;
using Photon.Pun;


public class Launcher : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        if (PhotonNetwork.IsConnected)
            return;

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectToMaster");
    }
}
