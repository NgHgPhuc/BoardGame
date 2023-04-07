using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CreatingRoomOptions : MonoBehaviour
{
    public TextMeshProUGUI MaxPlayers;
    public TMP_InputField RoomName;
    public TMP_Dropdown JoinMode;

    void Start()
    {
        MaxPlayers.SetText("5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveCreateRoomOption()
    {
        gameObject.SetActive(true);
    }
    public void ClickBackground()
    {
        gameObject.SetActive(false);
    }

    public void CreateButton() //Create Button
    {
        Lobby.Instance.CreateRoom(RoomName.text,Convert.ToInt16(MaxPlayers.text), Convert.ToBoolean(JoinMode.value));
    }
    public void Adjust_MaxPlayer_Button(int value)
    {
        if (Convert.ToInt16(MaxPlayers.text) * value == -2 || Convert.ToInt16(MaxPlayers.text) * value == 10) return;

        MaxPlayers.SetText((Convert.ToInt16(MaxPlayers.text) + value).ToString());
    }

    // 
    public void ClientSeenMode()
    {

    }
    public void HostSettingMode()
    {

    }
}
