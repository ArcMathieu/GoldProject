using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katia : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Achievement>().UnlockApromiseMadeIsApromiseKept();
        }
    }
}
