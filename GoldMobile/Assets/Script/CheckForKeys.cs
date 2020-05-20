using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForKeys : MonoBehaviour
{

    public string DesiredKey;
    public void actionDoor(GameObject Player)
    {
        Debug.Log("hi;)");
        for (int i = 0; i < Player.GetComponent<InventorySystem>().PlayerItems.Count; i++)
        {
            Debug.Log("ho");
            if (Player.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
            {
                Debug.Log("hi");
                gameObject.SetActive(false);
                FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
            }
        }
    }
    private void actionDoorCol(Collision2D collision)
    {
        for (int i = 0; i < collision.gameObject.GetComponent<InventorySystem>().PlayerItems.Count; i++)
        {
            if (collision.gameObject.GetComponent<InventorySystem>().PlayerItems[i].name == DesiredKey)
            {
                gameObject.SetActive(false);
                FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            actionDoorCol(collision);
        }
    }
}
