using System.Collections;
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

    public ObjectsInteractable Brosse;
    public ObjectsInteractable CinAfterTuto;
    public ObjectsInteractable cinAfterCoffre;
    public ObjectsInteractable CineEnding;
    public bool BossEnd3Objects;

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
        controleP1 = true;
        ChangeState();

    }
    public bool test;
    private void Start()
    {
        test = DataSaveProgress.isStart;
        if (DataSaveProgress.isStart)
        {
            FindObjectOfType<SaveSystem>().Load();
            FindObjectOfType<SaveSystem>().Revive();

        }
        else
        {
            FindObjectOfType<SaveSystem>().Reestart();
        }
        openStep();

    }

    public void showGhost(bool canAppears)
    {
        if (canAppears)
        {
            ghost.SetActive(true);

        }
        else ghost.SetActive(false);
    }

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
            CinAfterTuto.isReadyForCinematic = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[4].name)
        {
            //RecipRituel
            storyManager.BolRituel = true;
            FindObjectOfType<SaveSystem>().getObjRit2 = true;
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
            Brosse.isReadyForCinematic = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[7].name)
        {
            //cléCahmbreParents
            storyManager.DoorToMother = true;
            cinAfterCoffre.isReadyForCinematic = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[8].name)
        {
            //Brosse
            storyManager.BrosseACheveux = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[9].name)
        {
            //livre rituel
            storyManager.LivreRituel = true;
            FindObjectOfType<SaveSystem>().getObjRit3 = true;
        }
        if (ItemName == Player.GetComponent<InventorySystem>().PlayerItems[10].name)
        {
            //dague
            storyManager.dague = true;
            FindObjectOfType<SaveSystem>().getObjRit1 = true;
        }
        openStep();
    }

    public void Saving()
    {

        if (storyManager.CollierKatia)
        {
            FindObjectOfType<SaveSystem>().progress = 1;
            //if ()
            //{
            //    FindObjectOfType<SaveSystem>().progress = 2;
                if (storyManager.DoorToMother)
                {
                    FindObjectOfType<SaveSystem>().progress = 3;
                    if (storyManager.BrosseACheveux)
                    {
                        FindObjectOfType<SaveSystem>().progress = 4;
                        if (storyManager.DoorToSecreteCave)
                        {
                            FindObjectOfType<SaveSystem>().progress = 5;
                            if (storyManager.cinENDING)
                            {
                                FindObjectOfType<SaveSystem>().progress = 6;
                            }
                        }
                    }
                }
            //}
        }
        else FindObjectOfType<SaveSystem>().progress = 0;

        FindObjectOfType<SaveSystem>().Save();
    }

    public void openStep()
    {
        //Start
        if (!storyManager.START)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i < 6)
                {
                    tp[i].precedentlyOpened = true;
                }
                else
                {
                    tp[i].precedentlyOpened = false;
                }
            }
            tp[5].precedentlyOpened = false;
        }
        else
        {
            //main hall
            if (storyManager.CollierKatia)
            {

                for (int i = 5; i < 8; i++)
                {
                    tp[i].precedentlyOpened = true;

                }
                //FindObjectOfType<Lamp>().lightOn = false;

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
                tp[10].precedentlyOpened = true;
                tp[11].precedentlyOpened = true;

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
                if (storyManager.LivreRituel)
                {
                    CineEnding.isReadyForCinematic = true;
                    if (storyManager.BolRituel && storyManager.dague)
                    {
                        BossEnd3Objects = true;
                    }
                }

            }

            if (storyManager.cinENDING)
            {
                FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
                //end
            }
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
        }
        else if (selectPlayer)
        {
            CamP1.gameObject.SetActive(false);
            CamP2.gameObject.SetActive(true);
        }
    }
}
