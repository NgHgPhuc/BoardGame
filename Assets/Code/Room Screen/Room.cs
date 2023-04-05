using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

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
        UpdatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LeaveRoomButton()
    {
        PhotonNetwork.LeaveRoom();

    }

    public void StartButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel("Play Scene");
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Online Mode Scene");
    }

    void UpdatePlayer()
    {
        foreach (Transform child in PlayerSeat.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (KeyValuePair<int,Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            GameObject c = Instantiate(PlayerPref, PlayerSeat.transform);
            c.GetComponent<PlayerPanel>().SetName(player.Value.NickName);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayer();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayer();
    }
}
