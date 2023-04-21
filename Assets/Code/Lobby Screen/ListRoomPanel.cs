using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListRoomPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickBackground()
    {
        gameObject.SetActive(false);
    }
    public void OpenListRoomPanel()
    {
        gameObject.SetActive(true);
    }
}
