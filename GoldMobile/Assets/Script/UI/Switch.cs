using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public bool controlePlayer = false;

    public PlayerManager player;
    public GhostManager ghost;
    public GameManager gameManager;

    public GameObject ghostAppears;
    public Zone zone;

    public void DoAction()
    {
        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Image>().color = Color.black;
        }

        if (!controlePlayer && !zone.AlreadyInZone)
        {
            StartCoroutine(Waiting());
            IEnumerator Waiting()
            {
                yield return new WaitForSeconds(0.2f);
                ghost.ChangeControl();
                gameManager.openStep();
                controlePlayer = true;

            }
            
        } else
        {
            StartCoroutine(Waiting());
            IEnumerator Waiting()
            {
                yield return new WaitForSeconds(0.2f);
                player.ChangeControl();
                gameManager.openStep();
                controlePlayer = false;
            }
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(changeColor());
            IEnumerator changeColor()
            {
                GetComponent<Image>().color = Color.green;
                yield return new WaitForSeconds(0.2f);
                GetComponent<Image>().color = Color.black;
            }

            if (!controlePlayer)
            {
                StartCoroutine(Waiting());
                IEnumerator Waiting()
                {
                    yield return new WaitForSeconds(0.2f);
                    ghost.ChangeControl();
                    gameManager.openStep();
                    controlePlayer = true;

                }

            }
            else
            {
                StartCoroutine(Waiting());
                IEnumerator Waiting()
                {
                    yield return new WaitForSeconds(0.2f);
                    player.ChangeControl();
                    gameManager.openStep();
                    controlePlayer = false;
                }
            }

        }
    }
}
