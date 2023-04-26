using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineGameConnection : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Invoke("SetListener", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetListener()
    {
        GameHandler.Instance.HandlerOnlineMode.AddListener(this.HandlerOnlineMode);
        GameHandler.Instance.WinOnlineMode.AddListener(this.WinOnlineMode);
        SetGameCode();
    }

    public void HandlerOnlineMode(int TrueNumberCount, int TruePositionCount)
    {
        PlayerHandler.Instance.PlayerDoneTurn(TrueNumberCount, TruePositionCount);
    }

    public void WinOnlineMode()
    {
        PlayerHandler.Instance.FirstPlayerWin();
    }

    public void SetGameCode()
    {
        string OnlineCode = PlayerHandler.Instance.GetOnlineCode();
        List<string> GameCode = new List<string>();
        foreach (char c in OnlineCode)
            GameCode.Add(c.ToString());

        GameHandler.Instance.SetGameCode(GameCode);
    }
}
