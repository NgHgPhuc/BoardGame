using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
public class RoomInfoUI : MonoBehaviour
{
    public TextMeshProUGUI RoomInfoText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoomInfoText(Photon.Realtime.Room room)
    {
        string RoomCode = room.Name;
        int MaxPlayers = room.MaxPlayers;
        string Mode = room.IsOpen ? "Public" : "Private";
        RoomInfoText.SetText("Code : " + RoomCode + "\nMax players: " + MaxPlayers.ToString() + "\nJoin Mode: " + Mode);
    }
}
