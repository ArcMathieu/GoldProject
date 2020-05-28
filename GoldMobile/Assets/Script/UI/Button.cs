﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager ghost;
    public Invocation Circle;
    public void onClick()
    {
        if (player.PlayerState == PlayerManager.State.MOVABLE)
        {
            if (player.CurrentInteraction != null)
            {
                foreach (GameObject myObject in player.CurrentInteraction)
                {
                    myObject.SendMessage("setAction");

                }
            }
        }
        else
        {
            if (ghost.CurrentInteraction != null)
            {
                foreach (GameObject myObject in ghost.CurrentInteraction)
                {
                    Debug.Log("sdfghjk");
                    myObject.SendMessage("setAction");

                }
            }
        }


        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponentInChildren<Image>().color = Color.grey;
            yield return new WaitForSeconds(0.2f);
            GetComponentInChildren<Image>().color = Color.white;

        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.PlayerState == PlayerManager.State.MOVABLE)
            {
                if (player.CurrentInteraction != null)
                {
                    foreach (GameObject myObject in player.CurrentInteraction)
                    {
                        myObject.SendMessage("setAction");

                    }
                }
            }
            else
            {
                if (ghost.CurrentInteraction != null)
                {
                    foreach (GameObject myObject in ghost.CurrentInteraction)
                    {
                        myObject.SendMessage("setAction");

                    }
                }
            }

            StartCoroutine(changeColor());
            IEnumerator changeColor()
            {
                GetComponentInChildren<Image>().color = Color.grey;
                yield return new WaitForSeconds(0.2f);
                GetComponentInChildren<Image>().color = Color.white;

            }
        }
    }
}
