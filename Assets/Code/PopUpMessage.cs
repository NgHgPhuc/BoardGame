using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Message;

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMessagePopUp(string message)
    {
        Message.SetText(message);
    }
}
