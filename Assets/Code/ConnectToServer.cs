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
    public TMP_InputField FillName;

    void Start()
    {
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
        if (FillName.text.Length < 3) return;

        PhotonNetwork.NickName = FillName.text;
        PhotonNetwork.GameVersion = "1.0.0";
        status.SetText("Connecting to Online Mode");
        PhotonNetwork.ConnectUsingSettings();
    }
}
