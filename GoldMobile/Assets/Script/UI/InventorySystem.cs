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
        Items.Add(nameItem);
         
        foreach (GameObject Item in PlayerItems)
        {
            if (nameItem == Item.name)
            {
                Item.SetActive(true);
                numberofitems++;
                if(nameItem == PlayerItems[0].name || nameItem == PlayerItems[1].name || nameItem == PlayerItems[2].name)
                {
                    numberofitemsrituel++;
                }
            }
        }

        if (numberofitems == 11)
        {
            FindObjectOfType<Achievement>().UnlockSyllogomania();
        }

        if (numberofitemsrituel == 3)
        {
            FindObjectOfType<Achievement>().UnlockNeverSayDieKindaGuy();
        }
    }

}
