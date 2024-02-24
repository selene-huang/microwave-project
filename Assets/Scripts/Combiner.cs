using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    [SerializeField]
    private List<Recipe> recipes;
    public static Combiner combinerSingelton { get; private set; }
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
        }
    }

    public void combine(ItemInfo i1, ItemInfo i2)
    {
        Combination combo = new Combination(i1,i2);
        Combination reverseCombo = new Combination(i2, i1);
        foreach (Recipe recipe in recipes)
        {
            //if (recipe.combinations.Contains(combo) || recipe.combinations.Contains(reverseCombo)){
            // SpawnNewItem(recipe.Result);
            //}
            foreach(Combination combination in recipe.combinations)
            {
                if((combination.i1 == i1 && combination.i2 == i2) || (combination.i1 == i2 && combination.i2 == i1))
                {
                    SpawnNewItem(recipe.Result);
                    recipe.Result.SetIsDiscovered(true);
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
