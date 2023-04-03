using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoomItem : MonoBehaviour
{

    public void SetNameRoom(string name)
    {
        transform.Find("Room Name").GetComponent<TextMeshProUGUI>().SetText("RoomName: "+name);
    }
}
