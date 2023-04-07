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

    public bool IsTest;
    public static Room Instance { get; private set; }

    void Start()
    {
        UpdatePlayer();

        roomInfoUI.SetRoomInfoText(PhotonNetwork.CurrentRoom);

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        SceneManager.LoadScene("Online Mode Scene");
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Online Mode Scene");
    }


    //TESTING MODE

}
