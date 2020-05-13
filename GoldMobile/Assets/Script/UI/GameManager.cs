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
