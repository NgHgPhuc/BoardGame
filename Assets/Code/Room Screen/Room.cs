using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Unity.VisualScripting;

public class Room : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TextMeshProUGUI Roomname;
    public SeatPanel seatPanel;
    public RoomInfoUI roomInfoUI;
    public ActionPanelUI actionPanelUI;

    public bool IsTest;
    public static Room Instance { get; private set; }

    int ReadyPlayerCount;

    //ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    void Start()
    {
        PlayerJustJoinRoom_Handle(); // All action execute when player just joinroom

        //Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Action when player just entered or joined the room
    void PlayerJustJoinRoom_Handle()
    {
        PhotonNetwork.LocalPlayer.CustomProperties["isReady"] = false;

        UpdatePlayer(); //Show pre Join Player
        PlayerActionPanelShow(); //Show ready button or start button;
        roomInfoUI.SetRoomInfoText(PhotonNetwork.CurrentRoom);//set info room
    }

    public void LeaveRoomButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    void UpdatePlayer()
    {
        seatPanel.UpdatePlayerInRoom(PhotonNetwork.CurrentRoom);
        //PlayerActionPanelShow(); //if host out and you became a host => turn ready button into start button
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayer();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayer();
        PlayerActionPanelShow();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        //SceneManager.LoadScene("Online Mode Scene");
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Online Mode Scene");
    }

    //Show button start if player in master or ready if player is client
    void PlayerActionPanelShow()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient) //if client become master => turn ready mode into false
        {
            actionPanelUI.PlayerIsMaster();

            //ready mode into false
            PhotonNetwork.LocalPlayer.CustomProperties["isReady"] = false;
            var newHash = PhotonNetwork.LocalPlayer.CustomProperties;
            PhotonNetwork.LocalPlayer.SetCustomProperties(newHash);
            photonView.RPC("SyncPlayerReady", RpcTarget.All);
        }

        else actionPanelUI.PlayerIsClient();
    }

    public void PlayerClickReadyButton()
    {

        bool isReady = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isReady"];
        PhotonNetwork.LocalPlayer.CustomProperties["isReady"] = !isReady;
        var newHash = PhotonNetwork.LocalPlayer.CustomProperties;
        PhotonNetwork.LocalPlayer.SetCustomProperties(newHash);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["isReady"]);
        photonView.RPC("SyncPlayerReady", RpcTarget.All);

    }

    [PunRPC]
    void SyncPlayerReady()
    {
        seatPanel.UpdatePlayerReadyInRoom(PhotonNetwork.CurrentRoom.Players);
    }
    //public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    //{
    //    Debug.Log("Pro Update");
    //    photonView.RPC("SyncPlayerReady", RpcTarget.All);
    //}

    public void HostClickStartButton()
    {
        int currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int readyPlayerCount = seatPanel.ReadyCountInSeatPanel();
        Debug.Log(currentPlayerCount + "/" + readyPlayerCount);
        if (currentPlayerCount == 1) return;

        if (currentPlayerCount > seatPanel.ReadyCountInSeatPanel() + 1) return;

        PhotonNetwork.LoadLevel("Play Scene");

    }
}
