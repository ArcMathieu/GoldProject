using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<string> Items;
    public List<GameObject> PlayerItems;
    private int numberofitems;
    private int numberofitemsrituel;

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
        if (nameItem != "Bible")
        {
            Items.Add(nameItem);
        }
         
        foreach (GameObject Item in PlayerItems)
        {
            if (nameItem == Item.name)
            {
                Item.SetActive(true);
                numberofitems++;
                if(nameItem == PlayerItems[4].name || nameItem == PlayerItems[9].name || nameItem == PlayerItems[10].name)
                {
                    numberofitemsrituel++;
                }
            }
        }

        if (numberofitems == 11)
        {
            FindObjectOfType<Achievement>().UnlockCompulsiveHoarding();
        }

        if (numberofitemsrituel == 3)
        {
            FindObjectOfType<Achievement>().UnlockNeverSayDieKindaGuy();
        }
    }

    public void RemoveItems()
    {
        foreach (GameObject Item in PlayerItems)
        {
            Item.SetActive(false);
        }
    }

}
