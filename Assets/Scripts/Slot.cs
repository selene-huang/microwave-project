using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject itemInstance;
    public ItemInfo itemInfo;
    public int slotIndex;
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;
    public void ReciveData(ItemInfo itemInfo)
    {
        this.itemInfo = itemInfo;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(collision.gameObject, this.transform.position, Quaternion.identity);
    }
}

