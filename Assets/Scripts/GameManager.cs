using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static ItemInfo[] items;
    public static GameManager Instance = null;

    #region Unity Functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            items = Resources.LoadAll<ItemInfo>("Items/");
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
        return items.Length;
    }

    public ItemInfo GetItem(int i)
    {
        return items[i];
    }
    public void Discover(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name == item)
            {
                items[i].SetIsDiscovered(true);
            }
        }
    }
}
