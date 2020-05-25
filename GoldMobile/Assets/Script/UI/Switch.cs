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
    public GameObject pictureSwitch;
    public GameObject ghostAppears;
    public Zone zone;

    public void DoAction()
    {
        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Image>().color = Color.white;

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
                pictureSwitch.SetActive(false);
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
                pictureSwitch.SetActive(true);
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
                GetComponent<Image>().color = Color.grey;
                yield return new WaitForSeconds(0.2f);
                GetComponent<Image>().color = Color.white;

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
                    pictureSwitch.SetActive(false);
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
                    pictureSwitch.SetActive(true);
                }
            }

        }
    }
}
