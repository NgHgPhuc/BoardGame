using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Panel;
    public int Order;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton()
    {
        Panel[Order].SetActive(false);
        Order -= 1;
        if (Order < 0)
            Order = Panel.Count;
        Panel[Order].SetActive(true);
    }

    public void RightButton()
    {
        Panel[Order].SetActive(false);
        Order += 1;
        if (Order > Panel.Count-1)
            Order = 0;
        Panel[Order].SetActive(true);
    }
}
