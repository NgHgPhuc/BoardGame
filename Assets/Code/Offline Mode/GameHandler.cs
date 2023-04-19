using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    List<int> GameCode = new List<int>();
    int InputCount;
    public GameObject winPanel;
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
        RandomGameCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetGameCode()
    {
        return string.Join("", GameCode);
    }
    public int GetInputCount()
    {
        return InputCount;
    }
    public void RandomGameCode()
    {
        System.Random r = new System.Random();
        GameCode.Clear();
        GameCode.AddRange(Enumerable.Range(0, 10).OrderBy(x => r.Next()).Take(4));
        foreach (int i in GameCode)
        {
            Debug.Log(i);
        }
    }

    public void CheckValiadate(List<int> inputString)
    {
        if (inputString.SequenceEqual(GameCode))
        {
            winPanel.SetActive(true);
            InputCount = 0;
        }

        ShowInputPanel.Instance.NumberClear();
        InputCount++;
        string GuessedCode = string.Join("", inputString);
        int TrueNumberCount = this.TrueNumberCount(inputString);
        int TruePositionCount = this.TruePositionCount(inputString);

        ShowGuessedPanel.Instance.Serial_GuessedObject(GuessedCode, TrueNumberCount, TruePositionCount);

    }

    public int TrueNumberCount(List<int> inputString)
    {
        int Count = GameCode.Intersect(inputString).ToList().Count;
        return Count;
    }
    public int TruePositionCount(List<int> inputString)
    {
        int Count = 0;
        for(int i = 0 ; i < inputString.Count ; i++)
        {
            if (inputString[i] == GameCode[i])
                Count++;
        }

        return Count;

    }

    public void ResetGameHandle()
    {
        ShowInputPanel.Instance.NumberClear();
        RandomGameCode();
        ShowGuessedPanel.Instance.Reset_GuessedObject();
        InputCount = 0;
    }
}
