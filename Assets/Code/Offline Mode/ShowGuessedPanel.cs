using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowGuessedPanel : MonoBehaviour
{
    public Transform ShowGuessed;
    public GuessedObject guessedObject;
    public static ShowGuessedPanel Instance { get; private set; }
    Vector2 FirstSize;
    Vector3 FirstPos;

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

        FirstPos = ShowGuessed.GetComponent<RectTransform>().position;
        FirstSize = ShowGuessed.GetComponent<RectTransform>().sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Serial_GuessedObject(string GuessedCode, int TrueNumber, int TruePosition)
    {
        GuessedObject gO = Instantiate(guessedObject, ShowGuessed);
        gO.SerializeGuessed(GuessedCode, TrueNumber, TruePosition);
        ShowGuessed.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 160f);
        ShowGuessed.position = new Vector3(ShowGuessed.position.x, ShowGuessed.position.y - 80f, 0f);
    }

    public void Reset_GuessedObject()
    {
        foreach (Transform child in ShowGuessed)
            Destroy(child.gameObject);

        ShowGuessed.GetComponent<RectTransform>().position = FirstPos;
        ShowGuessed.GetComponent<RectTransform>().sizeDelta = FirstSize;
    }
}
