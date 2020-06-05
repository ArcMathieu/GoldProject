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
    //public bool ghostFollowing = false;
    public bool secreteTrap = false;
    public bool honoriaDoor = false;
    public DisplayText tdialogue;
    public DialogueData dialPlayer;
    public StoryGame storyManager;
    public bool Stairs;

    private bool once = true;
    private void Start()
    {
        tdialogue =GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            if (precedentlyOpened){
                if (canPass)
                {
                    if (!Stairs)
                    {
                        FindObjectOfType<SoundManager>().PlaySfx("Doors");
                    }
                    collision.transform.position = new Vector2(tpTo.transform.position.x, tpTo.transform.position.y);
                    //if (ghostFollowing)
                    //{
                        if (secreteTrap && once)
                        {
                            once = false;
                            FindObjectOfType<Achievement>().UnlockJillWouldBeProud();
                        }
                        ghost.transform.position = new Vector2(collision.transform.position.x +0.5f, collision.transform.position.y + 0.5f);
                    //}
                    try
                    {
                        GetComponent<Animator>().SetTrigger("opened");
                    }
                    catch { }

                    tpTo.SendMessage("CoroutToWait");

                }

            } else {
                tdialogue.isAutomatique = true;
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
                storyManager.START = true;
            }
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown("[1]")) //salon
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-84, 30);        
        //if (Input.GetKeyDown("[2]")) //couloir
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-97, 101);        
        //if (Input.GetKeyDown("[3]")) //honoria
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-73, 95);        
        //if (Input.GetKeyDown("[4]")) //mother
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-68, 116);        
        //if (Input.GetKeyDown("[5]")) // katia
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-37, 31);
        //if (Input.GetKeyDown("[6]")) //serre
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-37, 52);
        //if (Input.GetKeyDown("[7]")) //bibli
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-70, 49);
        //if (Input.GetKeyDown("[8]")) //cave
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-100, 10);
        //if (Input.GetKeyDown("[9]")) //secreteCave
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-75, 13);
        //if (Input.GetKeyDown("[0]")) //Boss ?
        //    FindObjectOfType<PlayerManager>().transform.position = new Vector2(-84, 30);

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
