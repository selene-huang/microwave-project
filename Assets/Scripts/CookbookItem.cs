using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookbookItem : MonoBehaviour
{
    private Image img;
    private TextMeshProUGUI txt;

    void Awake()
    {
        foreach (Image i in GetComponentsInChildren<Image>())
        {
            if (i.name == "Sprite")
            {
                img = i; 
                break;
            }
        }
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSprite(Sprite sprite)
    {
        img.sprite = sprite;
    }

    public void SetName(string name)
    {
        txt.text = name;
    }
}
