using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JoinRoomPanel : MonoBehaviour
{
    public TMP_InputField NameRoom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JoinRoom()
    {
        Lobby.Instance.JoinRoom(NameRoom.text);
    }
}
