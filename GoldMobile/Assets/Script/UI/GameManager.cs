﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject CamP1;
    public GameObject CamP2;
    public GameObject Player;
    public GameObject ghost;
    public bool controleP1 = false;

    public StoryGame storyManager;
    public PlayerManager player;
    public GhostManager gh;

    public ObjectsInteractable openSecretaire;
    public ObjectsInteractable Brosse;
    public ObjectsInteractable CinAfterTuto;
    public ObjectsInteractable cinAfterCoffre;
    public ObjectsInteractable CineEnding;

    public Tp[] tp;

    public float playerSpeed;
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        storyManager.Tuto = true;
        controleP1 = true;
        ChangeState();
        openStep();
    }

    public void showGhost(bool canAppears)
    {
        if (canAppears)
        {
            ghost.SetActive(true);  

        }else ghost.SetActive(false);
    }

    //public void IsFollowingGirl()
    //{
    //    for (int i = 0; i < tp.Length; i++)
    //    {
    //        tp[i].ghostFollowing = true;
    //    }
    //}

    public void launchCorout(float time)
    {
        StartCoroutine(waitForCinematique());
        IEnumerator waitForCinematique()
        {
            player.PlayerState = PlayerManager.State.WAIT;
            yield return new WaitForSeconds(time);
            player.PlayerState = PlayerManager.State.MOVABLE;
        }
    }

    public void TakeObject(string ItemName)
    {
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[0].name)
        {
            //secateur
            storyManager.Secateur = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[1].name)
        {
            //LockPick
            storyManager.Lockpick = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[2].name)
        {
            //pagesManquante
            storyManager.PageLivre = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[3].name)
        {
            //collier
            storyManager.CollierKatia = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[4].name)
        {
            //RecipRituel
            storyManager.BolRituel = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[5].name)
        {
            //pagesManquante
            storyManager.journalHonoria = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[6].name)
        {
            //CléSecretaire
            storyManager.CleSecretaire = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[7].name)
        {
            //cléCahmbreParents
            storyManager.DoorToMother = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[8].name)
        {
            //Brosse
            storyManager.BrosseACheveux = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[9].name)
        {
            //Brosse
            storyManager.LivreRituel = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[10].name)
        {
            //dague
            storyManager.dague = true;
        }
        openStep();
    }

    public void openStep()
    {
        //Start
        if (!storyManager.START)
        {
            for (int i = 0; i < 6; i++)
            {
               tp[i].precedentlyOpened = true;

            }
            tp[5].precedentlyOpened = false;
        } else {
            //main hall
            if (storyManager.CollierKatia)
            {
                CinAfterTuto.isReadyForCinematic = true;
                for (int i = 5; i < 8; i++)
                {
                    tp[i].precedentlyOpened = true;

                }
                //FindObjectOfType<Lamp>().lightOn = false;
                //IsFollowingGirl();
            }

        }

        if (storyManager.DoorToSerre)
        {
            //serre (lié à chambre)
            tp[8].precedentlyOpened = true;
            tp[9].precedentlyOpened = true;
        }

        if (storyManager.DoorToMother)
        {
            //mother room
            cinAfterCoffre.isReadyForCinematic = true;
            tp[10].precedentlyOpened = true;
            tp[11].precedentlyOpened = true;

            //pages livre
            if (storyManager.CleSecretaire)
            {
                Brosse.isReadyForCinematic = true;
            }

            //cinématique
            if (storyManager.BrosseACheveux)
            {
                //bruit bibli
                storyManager.DoorToBibli = true;
            }

        }

        if (storyManager.DoorToBibli)
        {
            //library
            tp[12].precedentlyOpened = true;
            tp[13].precedentlyOpened = true;

            //labyrinthe
            if (storyManager.Lockpick)
            {
                tp[14].precedentlyOpened = true;
                tp[15].precedentlyOpened = true;
                //open secrete cave
            }
            if (storyManager.LivreRituel && storyManager.BolRituel && storyManager.dague)
            {
                Debug.Log("vous avez les 3 objets du rituel");
                CineEnding.isReadyForCinematic = true;
            }

        }

        if (storyManager.cinENDING)
        {
            FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
            //end
        }


    }


    public void ChangeState()
    {
        switch (controleP1)   
        {
            case true:
                player.PlayerState = PlayerManager.State.MOVABLE;
                gh.GhostState = GhostManager.State.CONTROLLED;
                break;
            case false:
                player.PlayerState = PlayerManager.State.WAIT;
                gh.GhostState = GhostManager.State.MOVABLE;
                break;
            default:
                player.PlayerState = PlayerManager.State.MOVABLE;
                gh.GhostState = GhostManager.State.CONTROLLED;
                break;
        }
    }

    public void ChangeCamera(bool selectPlayer)
    {
        if (!selectPlayer)
        {
            CamP1.gameObject.SetActive(true);
            CamP2.gameObject.SetActive(false);
        }else if (selectPlayer)
        {
            CamP1.gameObject.SetActive(false);
            CamP2.gameObject.SetActive(true);
        }
    }
}
