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
    public TextMeshProUGUI Status;
    public TMP_InputField CreateRoomName;
    public TMP_InputField JoinRoomName;

    public GameObject RoomItemUI;
    public GameObject RoomListUI;
    
    private void Awake()
    {
        DestroyAllRoomListUI();
    }
    void Start()
    {
        Status.SetText("Hi, " + PhotonNetwork.NickName + "\nYOU ARE IN LOBBY");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        if (CreateRoomName.text.Length < 3) return;
        PhotonNetwork.CreateRoom(CreateRoomName.text);
    }
    public override void OnCreatedRoom()
    {
        SceneManager.LoadScene("Room Scene");
    }
    public void JoinRoom()
    {
        if (JoinRoomName.text.Length < 3) return;
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
        DestroyAllRoomListUI();
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList) continue;
            GameObject c = Instantiate(RoomItemUI, RoomListUI.transform);
            c.GetComponent<RoomItem>().SetNameRoom(roomInfo.Name);
        }
    }

    void DestroyAllRoomListUI()
    {
        foreach (Transform child in RoomListUI.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
