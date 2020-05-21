using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForKeys : MonoBehaviour
{

    public string DesiredKey;
    public ObjectsInteractable oi;

    private bool LAFOLIE = true;

    private void Start()
    {
        oi = GetComponent<ObjectsInteractable>();
    }
    public void actionDoor(GameObject Player)
    {
        for (int i = 0; i < Player.GetComponent<InventorySystem>().PlayerItems.Count; i++)
        {
            if (Player.GetComponent<InventorySystem>().PlayerItems[i].activeSelf == true && Player.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
            {
                oi.tdialogue.DialPass(oi.dialPlayer[0]);
                oi.tdialogue.NextDial();
                LAFOLIE = false;
                if (!LAFOLIE){
                    Player.GetComponent<InventorySystem>().PlayerItems[i].SetActive(false);
                    Player.GetComponent<InventorySystem>().AddItem(oi.ItemName);
                    GameManager._instance.TakeObject(oi.ItemName);
                    gameObject.SetActive(false);
                }
                if (DesiredKey == "Secateur")
                {
                    FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
                }
            }
        }
    }
    private void actionDoorCol(Collision2D collision)
    {
        for (int i = 0; i < collision.gameObject.GetComponent<InventorySystem>().PlayerItems.Count; i++)
        {
            if (collision.gameObject.GetComponent<InventorySystem>().PlayerItems[i].activeSelf == true && collision.gameObject.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
            {
                Debug.Log(";)");
                gameObject.SetActive(false);
                if (DesiredKey == "Secateur")
                {
                    FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
                }
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        actionDoorCol(collision);
    //    }
    //}
}
