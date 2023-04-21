using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpPrefab;
    public Transform PopupPanel;
    public static PopUpManager Instance { get; private set; }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePopUp(string message)
    {
        GameObject c = Instantiate(popUpPrefab, PopupPanel);
        c.GetComponent<PopUpMessage>().SetMessagePopUp(message);
    }
}
