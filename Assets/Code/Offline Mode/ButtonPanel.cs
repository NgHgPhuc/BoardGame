using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPanel : MonoBehaviour
{
    // Start is called before the first frame update
    List<int> InputString = new List<int>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<int> inputString()
    {
        return InputString;
    }
    public void ButtonNumberClick(int num)
    {
        if (InputString.Count >= 4) return;

        InputString.Add(num);
        ShowInputPanel.Instance.NumberShow(num);
    }
    public void ButtonDeleteClick()
    {
        if (InputString.Count == 0) return;

        InputString.RemoveAt(InputString.Count - 1);
        ShowInputPanel.Instance.NumberDelete();
    }
    public void ButtonClearClick()
    {
        InputString.Clear();
        ShowInputPanel.Instance.NumberClear();
    }

    public void ButtonEnterClick()
    {
        if (InputString.Count != 4) return;

        GameHandler.Instance.CheckValiadate(InputString);
        InputString.Clear();
    }

    public void MoreButtonClick(GameObject MorePanel)
    {
        MorePanel.SetActive(!MorePanel.activeSelf);
    }
    public void CloseClick()
    {
        SceneManager.LoadScene("Start Game Scene");
    }
}
