using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private string m_name;
    [SerializeField]
    private Sprite m_sprite;
    [SerializeField]
    private string m_description;
    [SerializeField]
    private bool m_isDiscovered;
    
    public string Name { 
        get { 
            return m_name; 
        } 
    }

    public Sprite Sprite
    {
        get { return m_sprite; }
    }

    public string Description { 
        get { 
            return m_description; 
        }
    }

    public bool IsDiscovered
    {
        get
        {
            return m_isDiscovered;
        }
    }

    public void SetIsDiscovered(bool d)
    {
        m_isDiscovered = d;
    }
}
