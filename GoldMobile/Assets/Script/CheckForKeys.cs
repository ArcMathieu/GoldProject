using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForKeys : MonoBehaviour
{

    public string DesiredKey;
    public ObjectsInteractable ObjectsInter;

    private bool LAFOLIE = true;

    public bool HasItem;
    private void Start()
    {
        ObjectsInter = GetComponent<ObjectsInteractable>();
    }
    public void actionDoor(GameObject Player)
    {
        for (int i = 0; i < Player.GetComponent<InventorySystem>().PlayerItems.Count; i++)
        {
            if (Player.GetComponent<InventorySystem>().PlayerItems[i].activeSelf == true && Player.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
            {
                HasItem = true;
                Player.GetComponent<InventorySystem>().PlayerItems[i].SetActive(false);
                ObjectsInter.tdialogue.DialPass(ObjectsInter.dialPlayer[0]);
                ObjectsInter.tdialogue.NextDial();
    //        
                if (DesiredKey == "Secateur")
                {
                    FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
                }
            }
        }
    }
    //private void actionDoorCol(Collision2D collision)
    //{
    //    for (int i = 0; i < collision.gameObject.GetComponent<InventorySystem>().PlayerItems.Count; i++)
    //    {
    //        if (collision.gameObject.GetComponent<InventorySystem>().PlayerItems[i].activeSelf == true && collision.gameObject.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
    //        {
    //            Debug.Log(";)");
    //            gameObject.SetActive(false);
    //            if (DesiredKey == "Secateur")
    //            {
    //                FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
    //            }
    //        }
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        actionDoorCol(collision);
    //    }
    //}
}
