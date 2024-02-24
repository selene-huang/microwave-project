using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    [SerializeField]
    private ItemInfo _result;


    [SerializeField]
    public List<Combination> combinations;

    public ItemInfo Result
    {
        get { return _result; }
    }
}

[Serializable]
public class Combination
{
    public ItemInfo i1;
    public ItemInfo i2;

    public Combination(ItemInfo i1, ItemInfo i2)
    {
        this.i1 = i1;
        this.i2 = i2;
    }
}