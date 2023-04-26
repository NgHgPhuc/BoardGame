using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Unity.VisualScripting;
using Photon.Pun.UtilityScripts;
using System.Numerics;
using System;

public class PlayerHandler : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public static PlayerHandler Instance { get; private set; }

    public int CurrentTurn { get; private set; }
    public int StartTurn;

    List<Player> PlayerOrder=new List<Player>();
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Player[] players = PhotonNetwork.PlayerList;
        Array.Sort(players, (x, y) => x.ActorNumber.CompareTo(y.ActorNumber));
        PlayerOrder.AddRange(players);

        StartTurn = 0;
        CurrentTurn = StartTurn;
        CheckIsPlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerDoneTurn(int TrueNumberCount,int TruePositionCount)
    {
        PhotonNetwork.LocalPlayer.CustomProperties["CorrectNumber"] = TrueNumberCount.ToString();
        PhotonNetwork.LocalPlayer.CustomProperties["CorrectPosition"] = TruePositionCount.ToString();
        var newHash = PhotonNetwork.LocalPlayer.CustomProperties;
        PhotonNetwork.LocalPlayer.SetCustomProperties(newHash);

        photonView.RPC("SyncPlayerObject", RpcTarget.All);

        photonView.RPC("NextTurn", RpcTarget.All);
    }

    [PunRPC]
    public void SyncPlayerObject()
    {
        AnotherPlayerScroll.Instance.UpdatePlayer(PlayerOrder[CurrentTurn]);
    }

    [PunRPC]
    public void NextTurn()
    {
        CurrentTurn++;
        if (CurrentTurn >= PhotonNetwork.CurrentRoom.PlayerCount + StartTurn)
            CurrentTurn = StartTurn;
        photonView.RPC("CheckIsPlayerTurn", RpcTarget.All);
    }
    [PunRPC]
    public void CheckIsPlayerTurn()
    {
        GuessNumberPanel.Instance.IsMyTurn((PhotonNetwork.LocalPlayer.ActorNumber == PlayerOrder[CurrentTurn].ActorNumber));
    }

    public void FirstPlayerWin()
    {
        PhotonNetwork.LoadLevel("Room Scene");
    }
    public string GetOnlineCode()
    {
        return (string)PhotonNetwork.CurrentRoom.CustomProperties["GameCode"];
    }
}
