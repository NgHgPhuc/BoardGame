using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System;
using System.Linq;

public class Lobby : MonoBehaviourPunCallbacks
{
    public InfomationPanel infomationPanel;
    public static Lobby Instance { get; private set; }
    public bool isTesting;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    public GameObject roomObject;
    public Transform roomObjectContainer;
    private void Awake()
    {
    }
    void Start()
    {
        //TESTING MODE
        //if (isTesting && PhotonNetwork.NetworkClientState == ClientState.PeerCreated)
        if (PhotonNetwork.NetworkClientState != ClientState.JoinedLobby)
        {
            PhotonNetwork.NickName = "Testing Mode";
            PhotonNetwork.GameVersion = "1.0.0";
            PhotonNetwork.ConnectUsingSettings();
        }

        playerProperties["SkinName"] = "Apple";
        playerProperties["isReady"] = false; //Only use in Room
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);

        infomationPanel.SetPlayerNameUI(PhotonNetwork.NickName);

        //SINGLETON
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

    //Player Properties
    public void ChangeSkinName(string skinName)
    {
        PhotonNetwork.LocalPlayer.CustomProperties["SkinName"] = skinName;
    }

    // LOBBY CREATE ROOM
    public void CreateRoom(string NameRoom,int MaxPlayer,bool joinMode) // 0 false public - 1 true private
    {
        if (NameRoom.Length < 3) return;
        if (MaxPlayer < 2 || MaxPlayer > 10) return;


        RoomOptions roomOptions = new RoomOptions { MaxPlayers = (byte)MaxPlayer, IsVisible = !joinMode };

        ExitGames.Client.Photon.Hashtable custProps = new ExitGames.Client.Photon.Hashtable();
        System.Random r = new System.Random();
        List<int> GameCode = new List<int>();
        GameCode.AddRange(Enumerable.Range(0, 10).OrderBy(x => r.Next()).Take(4));
        custProps.Add("GameCode", string.Join("", GameCode));

        roomOptions.CustomRoomProperties = custProps;

        PhotonNetwork.CreateRoom(NameRoom, roomOptions);
    }
    public override void OnCreatedRoom()
    {
        SceneManager.LoadScene("Room Scene");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
    }


    // LOBBY JOIN ROOM
    public void JoinRoom(string NameRoom) //my func
    {
        if (NameRoom.Length < 3) return;
        PhotonNetwork.JoinRoom(NameRoom);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PopUpManager.Instance.InstantiatePopUp(message);
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Room Scene");
    }


    //LOBBY LIST ROOM
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }
    void UpdateRoomList(List<RoomInfo> roomList)
    {
        DestroyAllRoomListUI();
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList) continue;
            GameObject c = Instantiate(roomObject, roomObjectContainer);
            string ShowPlayer = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
            c.GetComponent<RoomObject>().InstantiateRoomObject(ShowPlayer, roomInfo.Name);
        }
    }

    void DestroyAllRoomListUI()
    {
        foreach (Transform child in roomObjectContainer)
        {
            Destroy(child.gameObject);
        }
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); // call OnJoinedLobby
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
    }

}
