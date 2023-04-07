using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public Image PlayerIcon;
    public GameObject HostIcon;
    public GameObject ReadyIcon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerIsHost()
    {
        HostIcon.SetActive(true);  
    }
    public void SetPlayerNameUI(string Name)
    {
        PlayerName.SetText(Name);
    }
    public void SetPlayerIconUI(string SkinName)
    {
        PlayerIcon.sprite = SkinIcon.Instance.SkinCloset[SkinName];
        //Debug.Log(SkinName);
    }
}
