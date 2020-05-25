using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    private Animator anim;
    public  GameObject Player;
    public float PlayerPos;
    public DisplayText tdialogue;
    public DialogueData dialPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
        tdialogue = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>();
        Player = GameObject.FindGameObjectWithTag("Chara").GetComponentInChildren<GhostManager>(true).gameObject;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerPos = Player.transform.position.x - transform.position.x;
        anim.SetFloat("PlayerPositionX",PlayerPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GhostPlayer") && tdialogue.DoneDisplaying)
        {
            FindObjectOfType<Achievement>().UnlockCreature();
            tdialogue.DialPass(dialPlayer);
            tdialogue.isAutomatique = true;
            tdialogue.NextDial();
        }
    }
}

