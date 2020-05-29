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
    //public GameObject zoneDebug;

    public void DoAction()
    {
        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponentsInChildren<Image>()[0].color = Color.grey;
            GetComponentsInChildren<Image>()[1].color = Color.grey;
            yield return new WaitForSeconds(0.2f);
            GetComponentsInChildren<Image>()[0].color = Color.white;
            GetComponentsInChildren<Image>()[1].color = Color.white;

        }

        if (!controlePlayer && !zone.AlreadyInZone)
        {
            StartCoroutine(Waiting());
            IEnumerator Waiting()
            {
                FindObjectOfType<SoundManager>().PlaySfx("SpawnGhost");
                yield return new WaitForSeconds(0.2f);
                ghost.ChangeControl();
                gameManager.openStep();
                controlePlayer = true;
                pictureSwitch.SetActive(false);
            }

        }
        else if (controlePlayer)
        {
            StartCoroutine(Waiting());
            IEnumerator Waiting()
            {
                FindObjectOfType<SoundManager>().PlaySfx("SpawnGhost");
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
                GetComponentsInChildren<Image>()[0].color = Color.grey;
                GetComponentsInChildren<Image>()[1].color = Color.grey;
                yield return new WaitForSeconds(0.2f);
                GetComponentsInChildren<Image>()[0].color = Color.white;
                GetComponentsInChildren<Image>()[1].color = Color.white;

            }

            if (!controlePlayer && !zone.AlreadyInZone)
            {
                StartCoroutine(Waiting());
                IEnumerator Waiting()
                {

                    FindObjectOfType<SoundManager>().PlaySfx("SpawnGhost");
                    yield return new WaitForSeconds(0.2f);
                    ghost.ChangeControl();
                    gameManager.openStep();
                    controlePlayer = true;
                    pictureSwitch.SetActive(false);
                }

            }
            else if(controlePlayer)
            {
                StartCoroutine(Waiting());
                IEnumerator Waiting()
                {
                    yield return new WaitForSeconds(0.2f);
                    FindObjectOfType<SoundManager>().PlaySfx("SpawnGhost");
                    player.ChangeControl();
                    gameManager.openStep();
                    controlePlayer = false;
                    pictureSwitch.SetActive(true);
                }
            }

        }

        if (!controlePlayer && zone.AlreadyInZone)
        {
            GetComponentsInChildren<Image>()[0].color = Color.grey;
            GetComponentsInChildren<Image>()[1].color = Color.grey;
        }
        else
        {
            GetComponentsInChildren<Image>()[0].color = Color.white;
            GetComponentsInChildren<Image>()[1].color = Color.white;
        }
    }
}
