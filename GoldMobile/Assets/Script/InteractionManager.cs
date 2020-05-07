using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private int ID = 0;
    private bool isIn = false;
    public GhostManager ghost;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            isIn = true;
        }
    }

    void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Active");
            ghost.ChangeControl();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }
}
