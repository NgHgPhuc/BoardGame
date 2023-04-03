using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Room : MonoBehaviourPunCallbacks
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
        //GameObject c = PhotonNetwork.Instantiate(PlayerPref.name, Vector3.zero,Quaternion.identity);
        //c.transform.SetParent(PlayerSeat.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LeaveRoomButton()
    {
        PhotonNetwork.LeaveRoom();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Online Mode Scene");
    }
}
