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
    public DialogueData dial;
    public DisplayText tdialogue;
    public Zone zone;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ID == 1 && collision.gameObject.CompareTag("GhostPlayer"))
        {
            isIn = true;
            
        }
        if (ID == 0 && collision.gameObject.CompareTag("Player"))
        {
            isPIn = true;

        }
    }

    public void setAction()
    {
        if(isPIn)
         tdialogue.DialPass(dial);

        if (isIn)
        {
            zone.questStart = false;
            zone.questEnd = true;
            tdialogue.DialPass(dial);
            ghost.ChangeControl();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPIn = false;
        isIn = false;
    }
}
