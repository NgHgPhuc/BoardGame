using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class Lobby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TMP_InputField CreateRoomName;
    public TMP_InputField JoinRoomName;

    public GameObject RoomItemUI;
    public GameObject RoomListUI;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateRoomName.text);
    }
    public override void OnCreatedRoom()
    {
        SceneManager.LoadScene("Room Scene");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinRoomName.text);
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Room Scene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }
    void UpdateRoomList(List<RoomInfo> roomList)
    {
        RoomListUI.transform.chil
        foreach(RoomInfo roomInfo in roomList)
        {

        }
    }

}
