using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MicrowaveItems : MonoBehaviour
{
    [SerializeField]
    private Slot[] slots;
    [SerializeField]
    public GameObject HeldItem;
    [SerializeField] 
    public Combiner combiner;

    private void Start()
    {
        combiner = gameObject.GetComponent<Combiner>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HeldItem)
            {
                if (slots[0].itemInfo == null)
                {
                    slots[0].ReciveData(HeldItem.GetComponent<ItemInstance>().ItemInfo);
                    slots[0].spriteRenderer.sprite = slots[0].itemInfo.Sprite;
                }
                else if (slots[1].itemInfo == null)
                {
                    slots[1].ReciveData(HeldItem.GetComponent<ItemInstance>().ItemInfo);
                    slots[1].spriteRenderer.sprite = slots[1].itemInfo.Sprite;
                }
            }
            HeldItem = null;
        }
    }


    public void CombineItems()
    {
        ItemInfo i1 = slots[0].itemInfo;
        ItemInfo i2 = slots[1].itemInfo;
        combiner.combine(i1, i2);
        ClearSlots();
    }
    public void ClearSlots()
    {
        foreach(Slot slot in slots)
        {
            slot.itemInfo = null;
            slot.spriteRenderer.sprite = null;
        }
    }

}
