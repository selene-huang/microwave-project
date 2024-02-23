using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class ItemInformation
{
    public string name;
    public bool discovered;
    public bool isFinal;

    public ItemInformation(string n, bool isDiscovered) {
        name = n;
        discovered = isDiscovered;
        isFinal = false;
    }

    public ItemInformation(string n, bool isDiscovered, bool finalItem)
    {
        name = n;
        discovered = isDiscovered;
        isFinal = finalItem;
    }
}

public class GameManager : MonoBehaviour
{
    private static List<ItemInformation> items;
    public static GameManager Instance = null;

    #region Unity Functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            items = new List<ItemInformation>
            {
                {new ItemInformation("Water", true) },
                {new ItemInformation("Egg", true) },
                {new ItemInformation("Spoon", true) },
                {new ItemInformation("Knife", false) },
                {new ItemInformation("Fork", false) },
                {new ItemInformation("Life", false) },
                {new ItemInformation("Steam", false) },
                {new ItemInformation("Fire", false) },
                {new ItemInformation("Rabbit", false) },
                {new ItemInformation("Fish", false) },
                {new ItemInformation("Flamingo", false) },
                {new ItemInformation("Shrimp", false, true) },
                {new ItemInformation("Charcoal", false) },
                {new ItemInformation("Black Rabbit", false, true) },
                {new ItemInformation("Black Flamingo", false, true) },
                {new ItemInformation("Breakfast", false, true) },
                {new ItemInformation("Dinner", false, true) },
                {new ItemInformation("Steamed Egg", false, true) },
                {new ItemInformation("Cancer", false, true) },
                {new ItemInformation("Pink Egg", false, true) },
                {new ItemInformation("Black Egg", false, true) },
                {new ItemInformation("Bad Egg", false, true) },
                {new ItemInformation("Roe", false, true) },
                {new ItemInformation("Home", false, true) },
                {new ItemInformation("Bill", false, true) },
                {new ItemInformation("Living Spoon", false, true) },
                {new ItemInformation("Living Knife", false, true) },
                {new ItemInformation("Living Fork", false, true) },
                {new ItemInformation("Flying Rabbit", false, true) },
                {new ItemInformation("Flying Fish", false, true) },
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
        items.Find(i => i.name.Equals(item)).discovered = true;
    }
}
