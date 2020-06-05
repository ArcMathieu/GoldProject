using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ObjectsInteractable : MonoBehaviour
{
    public string ItemName;
    //public int ID = 0;
    public TimelineAsset Cinematic;
    public bool isIn = false;
    public bool isPIn = false;
    public bool notFirstTalkP = false;
    private bool notFirstTalkG = false;
    //private bool endQuest = false;
    public bool isPickable = false;
    public bool isLastCin = false;
    public GameObject TpBoss;

    //public GhostManager ghost;
    public DialogueData[] dialPlayer;
    public DialogueData[] dialGhost;
    public DisplayText tdialogue;
    public GameObject Player;

    public CheckForKeys DoorSytem;
    public ActivateLock LockSytem;

    public bool HasTalked;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        tdialogue = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>();
        DoorSytem = GetComponent<CheckForKeys>();
        LockSytem = GetComponent<ActivateLock>();
    }

    public void setAction()
    {
        if (isTrigger)
        {
            if (isPIn && HasTalked == false)
            {
                tdialogue.NextDial();
            }
        }
        if (Cinematic == null)
        {
            tdialogue.isAutomatique = false;
            //if (isIn)
            //{
            //    //ghost = GameObject.FindGameObjectWithTag("GhostPlayer").GetComponent<GhostManager>();
            //    if (!notFirstTalkG)
            //    {
            //        tdialogue.DialPass(dialGhost[0]);
            //        notFirstTalkG = true;
            //    }
            //    else
            //    {
            //        tdialogue.DialPass(dialGhost[1]);
            //    }
            //}

            if (isPIn && HasTalked == false)
            {
                if (DoorSytem == null)
                {

                    if (!notFirstTalkP)
                    {
                        //    if (DoorSytem != null)
                        //    {
                        //        DoorSytem.gameObject.SetActive(false);
                        //    }
                        tdialogue.DialPass(dialPlayer[0]);
                        notFirstTalkP = true;
                    }
                    else if (dialPlayer.Length == 2)
                    {
                        tdialogue.DialPass(dialPlayer[1]);
                    }

                    tdialogue.NextDial();
                }

                //if (LockSytem != null && notFirstTalkP)
                //{

                //    LockSytem.Action(Player);
                //}
                if (DoorSytem != null)
                {
                    if (DoorSytem.HasItem != true)
                    {
                        DoorSytem.actionDoor(Player);
                    }
                    else
                    {
                        tdialogue.NextDial();
                    }

                }
                else if (isPickable && ItemName != null)
                {
                    //tdialogue.DialPass(dialPlayer[0]);
                    Vibration.Vibrate(55);
                }


            }
        }
    }
    public void UnlockTheDoor()
    {
        Player.GetComponent<InventorySystem>().AddItem(ItemName);
        GameManager._instance.TakeObject(ItemName);
        gameObject.SetActive(false);
    }

    public void PickUpObject()
    {
        Player.GetComponent<InventorySystem>().AddItem(ItemName);
        GameManager._instance.TakeObject(ItemName);
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public bool isReadyForCinematic;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            isIn = true;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isPIn = true;
        }
    }

    public bool isTrigger;




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && tdialogue.DoneTalking)
        {

            if (Cinematic != null && isReadyForCinematic && DoorSytem == null && !notFirstTalkP && !isTrigger)
            {
                if (GameManager._instance.Shadow && isLastCin)
                {
                    FindObjectOfType<PlayerManager>().transform.position = new Vector2(TpBoss.transform.position.x + 1, TpBoss.transform.position.y);
                    FindObjectOfType<GhostManager>().transform.position = new Vector2(TpBoss.transform.position.x, TpBoss.transform.position.y - 1);
                }
                else
                {
                    tdialogue.isAutomatique = true;
                    PlayableDirector DP = GameObject.FindGameObjectWithTag("LD").GetComponent<PlayableDirector>();
                    DP.Play(Cinematic);
                    tdialogue.DialPass(dialPlayer[0]);
                    notFirstTalkP = true;
                    if (isPickable)
                    {
                        Player.GetComponent<InventorySystem>().AddItem(ItemName);
                        GameManager._instance.TakeObject(ItemName);
                    }

                }
            }
            else if (Cinematic != null && !notFirstTalkP && isReadyForCinematic && DoorSytem != null && !isTrigger)
            {
                tdialogue.isAutomatique = true;
                DoorSytem.actionDoor(Player);
                if (DoorSytem.HasItem)
                {
                    PlayableDirector DP = GameObject.FindGameObjectWithTag("LD").GetComponent<PlayableDirector>();
                    DP.Play(Cinematic);
                    notFirstTalkP = true;
                }
            }
            else if (Cinematic != null && !notFirstTalkP && isReadyForCinematic && DoorSytem == null && isTrigger)
            {
                tdialogue.isAutomatique = false;
                tdialogue.DialPass(dialPlayer[0]);
                PlayableDirector DP = GameObject.FindGameObjectWithTag("LD").GetComponent<PlayableDirector>();
                DP.Play(Cinematic);
                tdialogue.NextDial();
                notFirstTalkP = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //zone = null;
        if ((isPickable && Cinematic == null )|| (isTrigger && isReadyForCinematic))
        {
            if(notFirstTalkP)
                 HasTalked = true;
        }
        tdialogue.WantsToSkip = false;
        tdialogue.FirstTalk = true;
        tdialogue.tmpro.text = null;
        isPIn = false;
        isIn = false;
    }
}
