using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfomationPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI PlayerName;
    public GameObject PlayerIconSettingPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerNameUI(string playerName)
    {
        PlayerName.SetText(playerName);
    }
    public void ClickIcon()
    {
        PlayerIconSettingPanel.SetActive(true);
    }
}
