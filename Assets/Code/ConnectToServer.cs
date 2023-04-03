using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TextMeshProUGUI status;
    void Start()
    {
        //PhotonNetwork.GameVersion = "1.0.0";
        //PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); // call OnJoinedLobby
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Online Mode Scene");
    }

    public void OnlineMode()
    {
        PhotonNetwork.GameVersion = "1.0.0";
        status.SetText("Connecting to Online Mode");
        PhotonNetwork.ConnectUsingSettings();
    }
}
