using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedObject : MonoBehaviour
{
    public TextMeshProUGUI GuessedCode;
    public TextMeshProUGUI TrueNumber;
    public TextMeshProUGUI TruePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SerializeGuessed(string GuessedCode,int TrueNumber,int TruePosition)
    {
        this.GuessedCode.SetText(GuessedCode);
        this.TrueNumber.SetText(TrueNumber.ToString());
        this.TruePosition.SetText(TruePosition.ToString());
    }
}
