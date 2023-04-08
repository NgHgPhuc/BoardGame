using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPanelUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ReadyButton;
    public GameObject StartButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerIsClient()
    {
        ReadyButton.SetActive(true);
    }
    public void PlayerIsMaster()//master
    {
        StartButton.SetActive(true);
    }
    public void ClickReadyButton()
    {
        Room.Instance.PlayerClickReadyButton();
    }
    public void ClickStartButton()
    {

    }
    public void ClickLeaveButton()
    {
        Room.Instance.LeaveRoomButton();
    }
}
