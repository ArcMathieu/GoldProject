using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractable : MonoBehaviour
{
    public int ID = 0;
    private bool isIn = false;
    private bool isPIn = false;
    public InteractionManager interact;
    public GhostManager ghost;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ID == 1 && collision.gameObject.CompareTag("GhostPlayer"))
        {
            isIn = true;
            
        }
        if (ID == 0 && collision.gameObject.CompareTag("Player") && interact.isPressedButton)
        {
            isPIn = true;

        }
    }

    private void Update()
    {
         if (interact.isPressedButton)
        {
            if (isIn)
            {
                Debug.Log("activatedByGhost");
                ghost.ChangeControl();
                isIn = false;
            }
            if (isPIn)
            {
                Debug.Log("activatedByPlayer");
                isPIn = false;
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPIn = false;
        isIn = false;
    }
}
