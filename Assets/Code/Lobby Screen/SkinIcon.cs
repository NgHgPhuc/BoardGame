using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SkinIcon : MonoBehaviour
{
    public static SkinIcon Instance { get; private set; }

    public Dictionary<string, Sprite> SkinCloset { get; private set; }
    private void Awake()
    {
        SkinCloset = new Dictionary<string, Sprite>();
        SetSkinCloset();
    }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkinCloset()
    {
        Texture2D[] TextureList = Resources.LoadAll<Texture2D>("Skin/");
        foreach (Texture2D i in TextureList)
        {
            string Key = i.name;
            if (!SkinCloset.ContainsKey(Key))
            {
                Sprite sprite = Sprite.Create(i, new Rect(0, 0, i.width, i.height), new Vector2(0.5f, 0.5f));
                SkinCloset.Add(Key, sprite);
            }
        }
    }
}
