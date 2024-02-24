using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public ItemInfo itemInfo;
    public int slotIndex;
    public SpriteRenderer spriteRenderer;

    public void ReciveData(ItemInfo itemInfo)
    {
        this.itemInfo = itemInfo;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}

