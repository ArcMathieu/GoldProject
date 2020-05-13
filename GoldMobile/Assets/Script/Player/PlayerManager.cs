using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    public Joystick joystick;
    private bool isP1 = true;
    public GameManager gameManager;
    public GhostManager Player2;
    //public Transform GhostContainer;
    public Transform Ghost;
    public float currentRotation;

    public enum State {WAIT, MOVABLE }

    public State PlayerState;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        currentRotation = 0f;
        PlayerState = State.MOVABLE;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    void Update()
    {
        
        switch (PlayerState)
        {
            case State.WAIT:
                Waiting();
                break;
            case State.MOVABLE:
                Movable();
                break;
            default:
                break;
        }

    }

    public void Movable()
    {
        if (gameManager.controleP1)
        {
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * joystick.Vertical * speed) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed));

            //if (gameManager.firstRoom)
            //{
            //    Vector3 velocity = new Vector3();
            //    velocity.x = joystick.Horizontal;
            //    velocity.y = joystick.Vertical;
            //    velocity = velocity.normalized;
            //    Ghost.gameObject.SetActive(true);
            //    float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg + currentRotation;
            //    Quaternion rotationToReach = Quaternion.AngleAxis(angle, Vector3.forward);
            //    GhostContainer.rotation = Quaternion.RotateTowards(GhostContainer.rotation, rotationToReach, 270 * Time.deltaTime);
            //    //currentRotation = GhostContainer.rotation.z;
            //    Ghost.rotation = Quaternion.LookRotation(new Vector3(0, 1, -2), new Vector3(0, 1, -2));
            //    GhostContainer.position = transform.position;

            //}
            if(joystick.Vertical != 0 || joystick.Horizontal != 0)
            {
                anim.SetBool("isWalking", true);
                if(joystick.Horizontal < 0)
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }

        
    }
    
    public void Waiting()
    {
        //doNothing
        //Debug.Log("playerWait");
    }

    public void ChangeControl()
    {
        GameManager._instance.ChangeCamera(isP1);
        //Ghost.gameObject.SetActive(false);
        //gameManager.showGhost(true);
        StartCoroutine(WaitToControl());
        IEnumerator WaitToControl()
        {
            yield return new WaitForSeconds(0.2f);
            gameManager.controleP1 = false;
            GameManager._instance.ChangeState();
        }
    }
}
