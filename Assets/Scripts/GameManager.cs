using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public struct ItemInformation
{
    public int ID;
    public bool discovered;
    public bool isFinal;

    public ItemInformation(int id, bool isDiscovered) {
        ID = id;
        discovered = isDiscovered;
        isFinal = false;
    }

    public ItemInformation(int id, bool isDiscovered, bool finalItem)
    {
        ID = id;
        discovered = isDiscovered;
        isFinal = finalItem;
    }
}

public class GameManager : MonoBehaviour
{
    private static Dictionary<string, ItemInformation> items;
    public static GameManager Instance = null;

    #region Unity Functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            items = new Dictionary<string, ItemInformation>
            {
                {"Water", new ItemInformation(0, true) },
                {"Egg" , new ItemInformation(1, true) },
                {"Spoon", new ItemInformation(2, true) },
                {"Knife", new ItemInformation(3, false) },
                {"Fork", new ItemInformation(4, false) },
                {"Life", new ItemInformation(5, false) },
                {"Steam", new ItemInformation(6, false) },
                {"Fire", new ItemInformation(7, false) },
                {"Rabbit", new ItemInformation(8, false) },
                {"Fish", new ItemInformation(9, false) },
                {"Flamingo", new ItemInformation(10, false) },
                {"Shrimp", new ItemInformation(11, false, true) },
                {"Charcoal", new ItemInformation(12, false) },
                {"Black Rabbit", new ItemInformation(13, false, true) },
                {"Black Flamingo", new ItemInformation(14,false, true) },
                {"Breakfast", new ItemInformation(15, false, true) },
                {"Dinner", new ItemInformation(16, false, true) },
                {"Steamed Egg", new ItemInformation(17, false, true) },
                {"Cancer", new ItemInformation(18, false, true) },
                {"Pink Egg", new ItemInformation(19, false, true) },
                {"Black Egg", new ItemInformation(20, false, true) },
                {"Bad Egg", new ItemInformation(21, false, true) },
                {"Roe",  new ItemInformation(22, false, true) },
                {"Home", new ItemInformation(23, false, true) },
                {"Bill", new ItemInformation(24, false, true) },
                {"Living Spoon", new ItemInformation(25, false, true) },
                {"Living Knife",  new ItemInformation(26, false, true) },
                {"Living Fork", new ItemInformation(27, false, true) },
                {"Flying Rabbit", new ItemInformation(28, false, true) },
                {"Flying Fish", new ItemInformation(29, false, true) },
            };
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        // persists Game Manager across scenes
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public int GetNumItems()
    {
        return items.Count;
    }
    public void Discover(string item)
    {
        if (items.TryGetValue(item, out ItemInformation val))
        {
            val.discovered = true;
        }
    }
}
