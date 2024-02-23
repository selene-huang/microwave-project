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
}

[Serializable]
public class Combination
{
    public ItemInfo i1;
    public ItemInfo i2;
}