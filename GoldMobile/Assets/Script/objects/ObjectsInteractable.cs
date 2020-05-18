using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractable : MonoBehaviour
{
    public string ItemName;
    //public int ID = 0;
    private bool isIn = false;
    private bool isPIn = false;
    private bool notFirstTalkP = false;
    private bool notFirstTalkG = false;
    private bool endQuest = false;
    public bool isPickable = false;


    public GhostManager ghost;
    public DialogueData[] dialPlayer;
    public DialogueData[] dialGhost;
    public DisplayText tdialogue;
    public Zone zone;
    public InteractionManager interact;
    public GameObject firstObj;
    public GameObject Player;

    public void setAction()
    {
        if (tdialogue.DoneTalking) {
            tdialogue.NextDial();
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
                if (isPickable && tdialogue.DoneTalking && ItemName != null && notFirstTalkP)
                {
                    Debug.Log("Picked up");
                    Player.GetComponent<InventorySystem>().AddItem(ItemName);
                    Destroy(gameObject);
                }
                if (!endQuest)
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
                else if (dialPlayer.Length == 2)
                {
                    tdialogue.DialPass(dialPlayer[1]);
                }
             
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (/*ID == 1 && */collision.gameObject.CompareTag("GhostPlayer"))
        {
            isIn = true;

        }
        if (/*ID == 0 && */collision.gameObject.CompareTag("Player"))
        {
            isPIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //zone = null;
        isPIn = false;
        isIn = false;
    }
}
