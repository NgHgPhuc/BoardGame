using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInputPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public static ShowInputPanel Instance { get; private set; }
    public List<TextMeshProUGUI> ShowNumber;
    int Pointer=0;
    void Start()
    {
        //SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        NumberClear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NumberShow(int num)
    {
        string numTxt = num.ToString();
        ShowNumber[Pointer].SetText(numTxt);
        Pointer++;
    }
    public void NumberDelete()
    {
        if (Pointer == 0) return;

        ShowNumber[Pointer - 1].SetText("");
        Pointer--;
    }

    public void NumberClear()
    {
        foreach (TextMeshProUGUI t in ShowNumber)
            t.SetText("");
        Pointer = 0;
    }
}
