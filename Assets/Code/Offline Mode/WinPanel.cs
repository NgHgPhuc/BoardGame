using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinPanel : MonoBehaviour
{
    public TextMeshProUGUI ResultCount;
    public TextMeshProUGUI InputCount;
    private void Awake()
    {
        ResultCount.SetText(GameHandler.Instance.GetGameCode());
        InputCount.SetText(GameHandler.Instance.GetInputCount().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButtonClick()
    {
        SceneManager.LoadScene("Start Game Scene");
    }

    public void PlayAgain()
    {
        GameHandler.Instance.ResetGameHandle();
        gameObject.SetActive(false);
    }
}
