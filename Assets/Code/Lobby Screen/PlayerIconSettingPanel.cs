using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerIconSettingPanel : MonoBehaviour
{
    public Image FullBodySkin;//in player icon setting panel
    public Image IconPanel;//in player icon setting panel
    public Image IconInfo;//in Lobby - Player info
    public TextMeshProUGUI SkinName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseImageFromScroll(Image Skin)
    {
        FullBodySkin.sprite = Skin.sprite;
        IconPanel.sprite = Skin.sprite;
        IconInfo.sprite = Skin.sprite;
        SkinName.SetText(Skin.sprite.name);
        Lobby.Instance.ChangeSkinName(Skin.sprite.name);
    }

    public void ClickBackground()
    {
        gameObject.SetActive(false);
    }
}
