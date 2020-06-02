using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkJayZ : MonoBehaviour
{
    private GameObject Player;
    private GameObject Ghost;
    public GameObject CrossJayZ;
    public GameObject BubbleJayZ;
    public GameObject CurrentBubbleJayZ;

    private PlayerManager playerManager;
    private GhostManager ghostManager;
    private GameManager gameManager;

    private float Timer;
    public float TimerDuration;

    public Transform BloodPos;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ghostManager = FindObjectOfType<GhostManager>();
        Ghost = FindObjectOfType<GhostManager>().gameObject;
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();
        Timer = TimerDuration;
    }

    public enum State { Chill, Blood, Cross }
    public State BossState;
    // Update is called once per frame
    void Update()
    {
        DebugKey();

        switch (BossState)
        {
            case State.Chill:
                JayZsChilling();
                break;
            case State.Blood:
                AttackJayZsBlood();
                break;
            case State.Cross:
                AttackCrossJayZ();
                break;
        }
    }

    void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            BossState = State.Chill;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
          CurrentBubbleJayZ = Instantiate(BubbleJayZ, Player.transform.position, Quaternion.identity);
            BossState = State.Blood;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            BossState = State.Cross;
        }


    }

    public void JayZsChilling()
    {
        if(CurrentBubbleJayZ != null)
        {
            Destroy(CurrentBubbleJayZ);
        }
        Player.GetComponent<BoxCollider2D>().enabled = true;
        Player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        Player.GetComponentsInChildren<Animator>()[1].SetBool("isFloating", false);
        ghostManager.ChangeControl();
    }
    float t;
    public void AttackJayZsBlood()
    {
        Player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
        playerManager.ChangeControl();
        Player.GetComponentsInChildren<Animator>()[1].SetBool("isFloating", true);
        if (CurrentBubbleJayZ.GetComponent<BubbleJayZ>().PlayerBubbled)
        {
            Player.GetComponent<BoxCollider2D>().enabled = false;
            t += 0.008f * Time.deltaTime;
            Player.transform.position = Vector3.Lerp(Player.transform.position, BloodPos.position, t);
            CurrentBubbleJayZ.transform.position = Player.transform.position;
        }
    }

    public void AttackCrossJayZ()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = TimerDuration;
            Instantiate(CrossJayZ, Player.transform.position, Quaternion.identity);
        }
    }
}
