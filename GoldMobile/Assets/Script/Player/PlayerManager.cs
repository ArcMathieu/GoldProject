using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isDead;
    Rigidbody2D rb;
    private float speed;
    public Joystick joystick;
    public bool isP1 = true;
    public GameManager gameManager;
    public GhostManager Player2;
    public GameObject cadena;
    //public Transform GhostContainer;
    public Transform Ghost;
    public float currentRotation;

    //differents état du joueur
    public enum State { WAIT, MOVABLE }
    public State PlayerState;

    //Animation du joueur
    public Animator anim;

    //Objet dans lequel on est rentré en collision avec
    public List<GameObject> CurrentInteraction;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentsInChildren<Animator>()[1];
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        currentRotation = 0f;
        PlayerState = State.MOVABLE;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Add(collision.gameObject);
            try
            {
                collision.gameObject.GetComponent<ObjectsInteractable>().Player = gameObject;
            }
            catch { }
            if (collision.gameObject.name == "cadena")
            {
                cadena.SetActive(true);

            }
            Debug.Log(collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("creature"))
        {
            FindObjectOfType<Achievement>().UnlockCreature();
        }

        if (collision.gameObject.CompareTag("Armoire"))
        {
            if (collision.GetComponent<Animator>().GetBool("pushed"))
            {
                collision.GetComponent<Animator>().SetBool("pushed", false);
                FindObjectOfType<SoundManager>().PlaySfx("Armoire");
                Debug.Log("inArmorytrue");

            }
            else
            {
                collision.GetComponent<Animator>().SetBool("pushed", true);
                FindObjectOfType<SoundManager>().PlaySfx("Armoire");
                Debug.Log("inArmoryfalse");
            }
        }

        //if(collision.gameObject.CompareTag("coffre"))
        //{

        //}

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Remove(collision.gameObject);
        }
    }
    float t;
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 5);
        if (isDead == true)
        {
               t += 0.3f * Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(new Color(255, 255, 255, 1), new Color(255, 255, 255, 0), t);
        }
    
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
        if (gameManager.controleP1 && GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DisplayText>().DoneTalking && !isDead)
        {
            rb.MovePosition(transform.position + (((new Vector3(0, 1, 0) * joystick.Vertical * speed ) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed)) * Time.fixedDeltaTime));
            //Debug.Log("Horizontal" +joystick.Horizontal);
            //Debug.Log("Vertical" +joystick.Vertical);
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
        else
        {
            anim.SetBool("isWalking", false);
        }


    }
    
    public void Waiting()
    {
        //doNothing
        anim.SetBool("isWalking", false);
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
