using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject tpTo;
    public GameObject ghost;
    public bool canPass = false;
    public bool precedentlyOpened = false;
    //public bool stairs = false;
    public bool ghostFollowing = false;
    public bool secreteTrap = false;
    public bool honoriaDoor = false;
    public DisplayText tdialogue;
    public DialogueData dialPlayer;
    public StoryGame storyManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (precedentlyOpened){
                if (canPass)
                {
                    
                    collision.transform.position = new Vector2(tpTo.transform.position.x, tpTo.transform.position.y);
                    if (ghostFollowing)
                    {
                        ghost.transform.position = new Vector3(collision.transform.position.x +0.5f, collision.transform.position.y + 0.5f, 0);
                    }

                    tpTo.SendMessage("CoroutToWait");

                }

            } else {
                tdialogue.DialPass(dialPlayer);
            }
            //Secrete trap
            if (storyManager.Lockpick && secreteTrap)
            {
                storyManager.DoorToSecreteCave = true;
                GameManager._instance.openStep();
            }
            if (honoriaDoor)
            {
                storyManager.cinSTART = true;
            }
        }
    }

    public void CoroutToWait()
    {
        StartCoroutine(WaitToPass());
        IEnumerator WaitToPass()
        {
            canPass = false;
            yield return new WaitForSeconds(1);
            canPass = true;
        }
    }
}
