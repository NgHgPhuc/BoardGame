using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class RoomItem : MonoBehaviour
{
    //use for first test when learning photon
    public string NameRoom;
    public void SetNameRoom(string name)
    {
        NameRoom = name;
        transform.Find("Room Name").GetComponent<TextMeshProUGUI>().SetText("RoomName: "+name);
    }
    public void ClickOnRoom()
    {
        PhotonNetwork.JoinRoom(NameRoom);
    }
}
