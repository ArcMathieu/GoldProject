using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    private Animator anim;
    private  GameObject Player;
    public float PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerPos = Player.transform.position.x - transform.position.x;
        anim.SetFloat("PlayerPositionX",PlayerPos);
    }
}
