using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting;

public class SeatUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerUI_Pref;
    public GameObject InviteUI_Pref;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerInSeat(Player player,bool IsMaster)
    {
        GameObject c = Instantiate(PlayerUI_Pref, transform);
        PlayerPanel playerPanel = c.GetComponent<PlayerPanel>();
        playerPanel.SetPlayerNameUI(player.NickName);
        playerPanel.SetPlayerIconUI((string)player.CustomProperties["SkinName"]);
        if (IsMaster) playerPanel.PlayerIsHost();

    }
    public PlayerPanel GetPlayerInSeat()
    {
        PlayerPanel playerPanel = transform.GetChild(0).GetComponent<PlayerPanel>();
        return playerPanel;
    }

    public void InviteInSeat()
    {
        Instantiate(InviteUI_Pref, transform);
    }

    public void ClearSeat()
    {
        if (transform.childCount == 0) return;
        Destroy(transform.GetChild(0).gameObject);
    }
}
