using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System;

public class Lobby : MonoBehaviourPunCallbacks
{
    public InfomationPanel infomationPanel;
    public static Lobby Instance { get; private set; }
    public bool isTesting;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    private void Awake()
    {
    }
    void Start()
    {
        //TESTING MODE
        //if (isTesting && PhotonNetwork.NetworkClientState == ClientState.PeerCreated)
        if (isTesting)
        {
            PhotonNetwork.NickName = "Testing Mode";
            PhotonNetwork.GameVersion = "1.0.0";
            PhotonNetwork.ConnectUsingSettings();

            playerProperties["SkinName"] = "Apple";
            playerProperties["isReady"] = false; //Only use in Room
            PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
        }
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


        PhotonNetwork.CreateRoom(NameRoom, new RoomOptions { MaxPlayers = (byte)MaxPlayer ,IsVisible = !joinMode });
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
        Debug.Log(message);
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
        //DestroyAllRoomListUI();
        //foreach (RoomInfo roomInfo in roomList)
        //{
        //    if (roomInfo.RemovedFromList) continue;
        //    GameObject c = Instantiate(RoomItemUI, RoomListUI.transform);
        //    c.GetComponent<RoomItem>().SetNameRoom(roomInfo.Name);
        //}
    }

    void DestroyAllRoomListUI()
    {
        //foreach (Transform child in RoomListUI.transform)
        //{
        //    Destroy(child.gameObject);
        //}
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
