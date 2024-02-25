using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInstance : MonoBehaviour
{
    public ItemInfo m_itemInfo;

    private TextMeshPro m_name;

    private SpriteRenderer m_sprite;
    
    void Awake()
    {
        m_name = this.GetComponent<TextMeshPro>();
        m_sprite = GetComponent<SpriteRenderer>();
        //m_sprite.sprite = m_itemInfo.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Convert(ItemInfo item)
    {
        m_itemInfo = item;
        m_sprite.sprite = item.Sprite;
    }

    public ItemInfo ItemInfo { get { return m_itemInfo; } }
}
