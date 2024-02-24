using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Combiner : MonoBehaviour
{
    private Recipe[] recipes;
    public static Combiner combinerSingelton { get; private set; }
    private GameManager gm;

    [SerializeField]
    private Slot resultSlot;
    [SerializeField]
    private GameObject base_item;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (combinerSingelton != null && combinerSingelton!= this)
        {
            Destroy(this);
        }
        else
        {
            combinerSingelton = this;
            recipes = Resources.LoadAll<Recipe>("Recipes/");
            gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }
    }

    public void combine(ItemInfo i1, ItemInfo i2)
    {
        foreach (Recipe recipe in recipes)
        {
            foreach(Combination combination in recipe.combinations)
            {
                if((combination.i1 == i1 && combination.i2 == i2) || (combination.i1 == i2 && combination.i2 == i1))
                {
                    SpawnNewItem(recipe.Result);
                    gm.Discover(recipe.Result.Name);
                }
            }
        }
    }

    private void SpawnNewItem(ItemInfo itemInfo)
    {
        Debug.Log("Made Something");
        GameObject newItem = Instantiate(base_item, resultSlot.transform.position, Quaternion.identity);
        newItem.GetComponent<ItemInstance>().Convert(itemInfo);
    }


}
