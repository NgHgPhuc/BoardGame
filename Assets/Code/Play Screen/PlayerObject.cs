using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PlayerObject : MonoBehaviourPun
{
    // Start is called before the first frame update
    public Image PlayerIcon;
    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI CorrectNumber;
    public TextMeshProUGUI CorrectPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePlayerObject(Player player)
    {
        PlayerIcon.sprite = SkinIcon.Instance.SkinCloset[(string)player.CustomProperties["SkinName"]];
        PlayerName.SetText(player.NickName);
        CorrectNumber.SetText((string)player.CustomProperties["CorrectNumber"]);
        CorrectPosition.SetText((string)player.CustomProperties["CorrectPosition"]);
    }
}
