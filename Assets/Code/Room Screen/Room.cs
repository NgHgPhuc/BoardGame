using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class Room : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TextMeshProUGUI Roomname;
    public SeatPanel seatPanel;
    public RoomInfoUI roomInfoUI;
    public ActionPanelUI actionPanelUI;

    public bool IsTest;
    public static Room Instance { get; private set; }

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
        UpdatePlayer(); //Show pre Join Player
        PlayerActionPanelShow(); //Show ready button or start button;
        roomInfoUI.SetRoomInfoText(PhotonNetwork.CurrentRoom);//set info room
    }

    public void LeaveRoomButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void StartButton()
    {
    }

    void UpdatePlayer()
    {
        seatPanel.UpdatePlayerInRoom(PhotonNetwork.CurrentRoom);
        PlayerActionPanelShow(); //if host out and you became a host => turn ready button into start button
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayer();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayer();
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
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
            actionPanelUI.PlayerIsMaster();
        else actionPanelUI.PlayerIsClient();
    }
    public void PlayerClickReadyButton()
    {
        bool isReady = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isReady"];
        PhotonNetwork.LocalPlayer.CustomProperties["isReady"] = !isReady;
        photonView.RPC("SyncPlayerReady",RpcTarget.All );
    }

    [PunRPC]
    void SyncPlayerReady()
    {
        seatPanel.UpdatePlayerReadyInRoom(PhotonNetwork.CurrentRoom.Players);
    }


    void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps)
    {

    }
}
