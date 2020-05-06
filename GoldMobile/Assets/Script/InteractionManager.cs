using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private bool isIn = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isIn = true;
        }
    }

    void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.E))
            Debug.Log("Active");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }
}
