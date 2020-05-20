using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractable : MonoBehaviour
{
    public string ItemName;
    //public int ID = 0;
    public bool isIn = false;
    public bool isPIn = false;
    public bool notFirstTalkP = false;
    private bool notFirstTalkG = false;
    //private bool endQuest = false;
    public bool isPickable = false;
    public bool isDiscoveredByHonoria = false;


    //public GhostManager ghost;
    public DialogueData[] dialPlayer;
    public DialogueData[] dialGhost;
    public DisplayText tdialogue;
//    public InteractionManager interact;
    public GameObject Player;

    private CheckForKeys DoorSytem;

    private void Start()
    { 
       Player = GameObject.FindGameObjectWithTag("Player");
        tdialogue = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>();
        DoorSytem = GetComponent<CheckForKeys>();
    }
    public void setAction()
    {
       
        if (tdialogue.DoneTalking) {
            tdialogue.NextDial();
            if (isIn)
            {
                //ghost = GameObject.FindGameObjectWithTag("GhostPlayer").GetComponent<GhostManager>();
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
                if (DoorSytem != null)
                {
                    Debug.Log("Collision");
                    DoorSytem.actionDoor(Player);
                }

                if (isPickable && tdialogue.DoneTalking && ItemName != null)
                {
                    StartCoroutine(waitForDestroy());
                    IEnumerator waitForDestroy()
                    {
                        Debug.Log("Picked up");
                        tdialogue.DialPass(dialPlayer[0]);
                        Player.GetComponent<InventorySystem>().AddItem(ItemName);
                        GameManager._instance.TakeObject(ItemName);
                        yield return new WaitForSeconds(1);
                        Destroy(gameObject);
                    }

                }
                if (isDiscoveredByHonoria)
                {
                    //action si Honoria à vu un obj
                }
                //if (!endQuest)
                //{

                //    zone.questStart = false;
                //    zone.questEnd = true;
                //    ghost.GhostState = GhostManager.State.CONTROLLED;
                //}
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
