using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKey : MonoBehaviour
{

    public string DesiredKey;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<InventorySystem>().AddItem(DesiredKey);
            collision.gameObject.GetComponent<InventorySystem>().Items.Add(DesiredKey);
            Destroy(gameObject);
        }
    }
}
