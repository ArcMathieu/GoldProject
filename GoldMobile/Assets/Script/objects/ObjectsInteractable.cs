﻿using System.Collections;
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
    private ActivateLock LockSytem;

    public bool HasItem;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        tdialogue = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>();
        DoorSytem = GetComponent<CheckForKeys>();
        LockSytem = GetComponent<ActivateLock>();
    }

    private void Update()
    {

    }

    public void setAction()
    {

        if (tdialogue.DoneTalking)
        {
            if (DoorSytem == null)
            {
                tdialogue.NextDial();
            }

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

                if (LockSytem != null && tdialogue.DoneTalking && notFirstTalkP)
                {
                    Debug.Log("hpppiooii");
                    LockSytem.Action(Player);
                }
                else if (DoorSytem != null)
                {
                    DoorSytem.actionDoor(Player);
                    Debug.Log("hiii");
                }
                else if (isPickable && tdialogue.DoneTalking && ItemName != null)
                {
                    Debug.Log("hiooii");
                    StartCoroutine(waitForDestroy());
                    IEnumerator waitForDestroy()
                    {
                        tdialogue.DialPass(dialPlayer[0]);
                        Player.GetComponent<InventorySystem>().AddItem(ItemName);
                        GameManager._instance.TakeObject(ItemName);
                        yield return new WaitForSeconds(1);
                        Destroy(gameObject);
                    }
                }
                if (DoorSytem == null)
                {
                    if (!notFirstTalkP)
                    {
                        if (tdialogue.DoneTalking && DoorSytem != null)
                        {
                            DoorSytem.gameObject.SetActive(false);
                        }
                        tdialogue.DialPass(dialPlayer[0]);
                        notFirstTalkP = true;
                    }
                    else if (dialPlayer.Length == 2)
                    {
                        tdialogue.DialPass(dialPlayer[1]);
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
