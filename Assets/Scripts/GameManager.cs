using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static ItemInfo[] items;
    private static int numDiscovered = 0;
    public static GameManager Instance = null;

    #region Unity Functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            items = Resources.LoadAll<ItemInfo>("Items/");
            foreach (ItemInfo i in items)
            {
                if (i.IsDiscovered)
                {
                    numDiscovered++;
                }
            }
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

    public int GetNumDiscoveredItems()
    {
        return numDiscovered;
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
                if (!items[i].IsDiscovered)
                {
                    numDiscovered++;
                }
                items[i].SetIsDiscovered(true);
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
