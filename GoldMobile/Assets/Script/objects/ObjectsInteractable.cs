using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractable : MonoBehaviour
{
    public int ID = 0;
    private bool isIn = false;
    private bool isPIn = false;
    private bool notFirstTalkP = false;
    private bool notFirstTalkG = false;
    public bool endQuest = false;
    public bool picked = false;


    public GhostManager ghost;
    public DialogueData[] dialPlayer;
    public DialogueData[] dialGhost;
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
        if (isIn)
        {
            if (!notFirstTalkG)
            {
                tdialogue.DialPass(dialGhost[0]);
                notFirstTalkG = true;
            }
            else
            {
                tdialogue.DialPass(dialGhost[1]);
            }
        }

        if (isPIn)
        {
            if (endQuest)
            {
                zone.questStart = false;
                zone.questEnd = true;
                ghost.GhostState = GhostManager.State.CONTROLLED;
            }
            if (!notFirstTalkP)
            {
                tdialogue.DialPass(dialPlayer[0]);
                notFirstTalkP = true;
            }
            else
            {
                tdialogue.DialPass(dialPlayer[1]);
            }
            if (picked)
            {
                //ramasser l'obj
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPIn = false;
        isIn = false;
    }
}
