using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookbookItem : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }
}
