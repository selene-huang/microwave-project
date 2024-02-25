using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MicrowaveItems : MonoBehaviour
{
    [SerializeField]
    private Slot[] slots;
    [SerializeField]
    public GameObject HeldItem;
    [SerializeField] 
    public Combiner combiner;
    [SerializeField]
    public GameObject microwave;
    Animator animator;

    private void Start()
    {
        combiner = gameObject.GetComponent<Combiner>();
        animator = microwave.GetComponent<Animator>();
    }

 
    private void Update()
    {
        if (slots[0].GetComponent<Slot>().itemInfo == null && slots[1].GetComponent<Slot>().itemInfo == null)
        {
            animator.SetBool("Occupied", false);
        }
        else
        {
            animator.SetBool("Occupied", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (HeldItem)
            {
                Slot closestSlot = null;
                float minDistance = 1;
                float currDist = float.MaxValue;
                foreach (Slot slot in slots)
                {
                   
                    float dist = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), slot.transform.position);
                    Debug.DrawLine(Input.mousePosition, slot.transform.position);
                    Debug.Log(dist);

                    if (dist < minDistance && dist < currDist && slot.itemInfo == null)
                    {
                        closestSlot = slot;
                        currDist = dist;
                    }
                }
                if (closestSlot != null && closestSlot.itemInfo == null )
                {
                    closestSlot.ReciveData(HeldItem.GetComponent<ItemInstance>().ItemInfo);
                    //closestSlot.itemInstance = Instantiate(HeldItem, closestSlot.transform.position, Quaternion.identity)
                    closestSlot.spriteRenderer.sprite = closestSlot.itemInfo.Sprite;
                }
                if (slots[0].itemInfo == null)
                {
                    //slots[0].ReciveData(HeldItem.GetComponent<ItemInstance>().ItemInfo);
                    //slots[0].spriteRenderer.sprite = slots[0].itemInfo.Sprite;
                }
                else if (slots[1].itemInfo == null)
                {
                    //slots[1].ReciveData(HeldItem.GetComponent<ItemInstance>().ItemInfo);
                    //slots[1].spriteRenderer.sprite = slots[1].itemInfo.Sprite;
                }
            }
            HeldItem = null;
        }
    }


    public void CombineItems()
    {
        ItemInfo i1 = slots[0].itemInfo;
        ItemInfo i2 = slots[1].itemInfo;
        ClearSlots();
        combiner.combine(i1, i2);
    }
    public void ClearSlots()
    {
        foreach(Slot slot in slots)
        {
            //Destroy(slot.gameObject);
            slot.itemInfo = null;
            slot.spriteRenderer.sprite = slot.defaultSprite;
        }
    }

}
