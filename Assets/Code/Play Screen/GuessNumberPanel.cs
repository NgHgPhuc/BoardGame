using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessNumberPanel : MonoBehaviour
{
    // Start is called before the first frame update

    public static GuessNumberPanel Instance { get; private set; }

    public GameObject ShowInputPanel;
    public GameObject HistoryPanel;
    public GameObject ButtonPanel;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsMyTurn(bool isMyTurn)
    {
        ShowInputPanel.SetActive(isMyTurn);
        ButtonPanel.SetActive(isMyTurn);
    }
}
