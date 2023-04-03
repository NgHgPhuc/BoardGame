using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPanel : MonoBehaviour
{
    public string PlayerName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        PlayerName = name;
        transform.Find("Player Name").GetComponent<TextMeshProUGUI>().SetText(PlayerName);
    }
}
