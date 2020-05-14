using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    private bool isP1 = false;
    public Joystick joystick;
    public GameManager gameManager;
    public PlayerManager Player1;

    public GameObject barM;
    public Transform Player;
    public bool detected;
    public float distanceDetect = 10f;

    public GameObject footP1;
    public GameObject footP2;
    public GameObject MyPlayer;

    private Animator anim;
    public enum State { CONTROLLED, WAIT, MOVABLE }

    public State GhostState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        GhostState = State.WAIT;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        switch (GhostState)
        {
            case State.CONTROLLED:
                Controlled();
                break;
            case State.WAIT:
                Wait();
                break;
            case State.MOVABLE:
                Movable();
                break;
            default:
                break;
        }

        if (footP1.gameObject.transform.position.x < footP2.gameObject.transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {   
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        //passage de layer devant
        if (footP1.gameObject.transform.position.y > footP2.gameObject.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

    }

    public void Movable()
    {
        if (!gameManager.controleP1)
        {
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * joystick.Vertical * speed) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed));
            anim.SetBool("Walk", true);
        }

    }

    public void Controlled()
    {
       rb.MovePosition(Vector2.MoveTowards(transform.position, MyPlayer.transform.position, speed));
        anim.SetBool("Walk", true);
    }

    public void Wait()
    {
        //Stay at this position
        anim.SetBool("Walk", false);
    }

    public void ChangeControl()
    {
        GameManager._instance.ChangeCamera(isP1);
        StartCoroutine(WaitToControl());
        IEnumerator WaitToControl()
        {
            yield return new WaitForSeconds(0.2f);
            gameManager.controleP1 = true;
            GameManager._instance.ChangeState();
            //gameManager.showGhost(false);
        }
    }
}
