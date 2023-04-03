using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Roomname;
    public GameObject PlayerPref;
    public GameObject PlayerSeat;
    private void Awake()
    {
        Roomname.SetText(PhotonNetwork.CurrentRoom.Name);
    }
    void Start()
    {
        GameObject c = PhotonNetwork.Instantiate(PlayerPref.name, Vector3.zero,Quaternion.identity);
        c.transform.SetParent(PlayerSeat.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
