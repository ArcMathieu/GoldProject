using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<string> Items;
    public List<GameObject> PlayerItems;

    // Update is called once per frame
    void Start()
    {
    foreach(GameObject Item in PlayerItems)
        {
            Item.SetActive(false);
        }
    }

    public void AddItem(string nameItem)
    {
        Items.Add(nameItem);
         
        foreach (GameObject Item in PlayerItems)
        {
            if (nameItem == Item.name)
            {
                Item.SetActive(true);
                break;
            }
        }
    }
}
