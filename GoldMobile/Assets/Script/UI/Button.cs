using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager ghost;
    public DisplayText dialogue;
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

    bool wait;

    public void Update()
    {
        //sprites
        if (dialogue.DoneTalking)
        {
            if (wait)
            {
                StartCoroutine(waitToUndisplay());
                IEnumerator waitToUndisplay()
                {
                    yield return new WaitForSeconds(0.2f);
                    wait = false;
                }
            }
            else
            {
                if (player.CurrentInteraction.Count != 0 )
                {
                    try
                    {
                        if (player.CurrentInteraction[0].GetComponent<ObjectsInteractable>().isReadyForCinematic)
                        {
                            transform.GetChild(0).gameObject.SetActive(false);
                            transform.GetChild(1).gameObject.SetActive(false);
                        }
                    }
                    catch
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                        transform.GetChild(1).gameObject.SetActive(false);
                    }
                    
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        } else if (!dialogue.DoneTalking)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            wait = true;
        }
       

        //code
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
