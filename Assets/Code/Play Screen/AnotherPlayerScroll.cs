using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class AnotherPlayerScroll : MonoBehaviourPun
{
    // Start is called before the first frame update
    public static AnotherPlayerScroll Instance { get; private set; }
    public GameObject playerObject;
    public Transform Container;
    public Dictionary<int, GameObject> ListPlayer=new Dictionary<int, GameObject>();

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    private void Awake()
    {
    }
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

        gameObject.SetActive(false);

        playerProperties["CorrectNumber"] = "|";
        playerProperties["CorrectPosition"] = "|";
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);

        FirstInstantiatePlayerObject(PhotonNetwork.CurrentRoom.Players);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstInstantiatePlayerObject(Dictionary<int,Player> players)
    {
        foreach(KeyValuePair<int, Player> player in players)
        {
            GameObject c = Instantiate(playerObject, Container);
            c.GetComponent<PlayerObject>().InstantiatePlayerObject(player.Value);
            ListPlayer.Add(player.Value.ActorNumber, c);
        }
    }

    public void UpdatePlayer(Player player)
    {
        ListPlayer[player.ActorNumber].GetComponent<PlayerObject>().InstantiatePlayerObject(player);
    }
}
