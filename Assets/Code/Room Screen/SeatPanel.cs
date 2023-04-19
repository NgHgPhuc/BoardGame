using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class SeatPanel : MonoBehaviour
{
    // Start is called before the first frame update
    int ReadyCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerInRoom(Photon.Realtime.Room room)
    {
        foreach (Transform child in transform)
            child.GetComponent<SeatUI>().ClearSeat();

        int Count = 0;
        foreach (KeyValuePair<int, Player> player in room.Players)
        {
            transform.GetChild(Count).GetComponent<SeatUI>().SetPlayerInSeat(player.Value, player.Value.IsMasterClient);

            Count++;
        }

        int PlayerCount = room.PlayerCount;
        if (PlayerCount >= 10 || PlayerCount == room.MaxPlayers) return;

        transform.GetChild(PlayerCount).GetComponent<SeatUI>().InviteInSeat();
    }

    public void UpdatePlayerReadyInRoom(Dictionary<int,Player> Players)
    {
        int Count = 0;
        ReadyCount = 0;
        foreach (KeyValuePair<int, Player> player in Players)
        {
            bool isReady = (bool)player.Value.CustomProperties["isReady"];

            ReadyCount = isReady ? ++ReadyCount : ReadyCount;

            transform.GetChild(Count).GetComponent<SeatUI>().GetPlayerInSeat().PlayerClickReady(isReady);
            Count++;
        }

    }

    public int ReadyCountInSeatPanel()
    {
        return ReadyCount;
    }
}
