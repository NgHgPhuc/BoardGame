using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RoomObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HostIcon;
    public TextMeshProUGUI PlayerCountInRoom;
    public TextMeshProUGUI RoomName;
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateRoomObject(string PlayerCountInRoom,string RoomName)
    {
        this.PlayerCountInRoom.SetText(PlayerCountInRoom);
        this.RoomName.SetText(RoomName);
    }

    public string GetRoomObjectName()
    {
        return this.RoomName.text;
    }

    public void EnterInRoomObject()
    {
        Lobby.Instance.JoinRoom(this.RoomName.text);
    }
}
