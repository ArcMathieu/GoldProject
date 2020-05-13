using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject P1;
    public GameObject P2;
    public GameObject ghost;
    public bool controleP1 = false;
    public bool firstRoom = false;

    public PlayerManager player;
    public GhostManager gh;

    public float playerSpeed;
    public int incrementStep = 0;
    private void Awake()
    {
        controleP1 = true;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void showGhost(bool canAppears)
    {
        if (canAppears)
        {
            ghost.SetActive(true);  

        }else ghost.SetActive(false);
    }

    public void openStep()
    {
        firstRoom = true;
        if (incrementStep == 0)
        {
            //Exterieur
            //cinematique
            //chambre mother, sous sol 2, serre & librairy fermés

            //incrementStep++;
        }

        if (incrementStep == 1)
        {
            //main hall
            //lumière on + déplacement libre joueur
            //dialogue postIntro
            // dialogue chambre fille
            //incrementStep++;

            //chambre girl
            //wait invocation 
            //tuto sel
            //lumière off && invoc petite fille + halo de lumière

            //sous sol 1
            //secateur
            //flashBack / vision de fantome

            //Lily chambre
            //interaction => tapis+latte
            //boite code 

            //librairy closed, mother room closed 

            //incrementStep++;

        }

        if (incrementStep == 2)
        {
            //serre (lié à chambre)
            //cinématique lié bout de verre
            //using sécateur => clé + journal
            //code sur pilier

            //incrementStep++;
        }

        if (incrementStep == 3)
        {
            //library
            //labyrinthe
            //wait for doors 
            //clé to mother room

            //incrementStep++;

        }

        if (incrementStep == 4)
        {
            //mother room
            //pages livre
            //cinématique
            //outil to trappe du sous sol

            //incrementStep++;

        }

        if (incrementStep == 5)
        {
            //sous sol 2 fond de la librairy
            //R sauf cinématique

            //incrementStep++;

        }

        if (incrementStep == 6)
        {
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
            P1.gameObject.SetActive(true);
            P2.gameObject.SetActive(false);
        }else if (selectPlayer)
        {
            P1.gameObject.SetActive(false);
            P2.gameObject.SetActive(true);
        }
    }
}
