using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInstance : MonoBehaviour
{
    public ItemInfo m_itemInfo;

    private Text m_name;

    private Image m_image;
    
    void Start()
    {
        m_name = this.GetComponentInChildren<Text>();
        m_image = GetComponent<Image>();
        m_name.text = m_itemInfo.Name;
        m_image.sprite = m_itemInfo.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
