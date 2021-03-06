﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    private bool isP1 = false;
    //public  GameObject GhostEffectHUD;
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

    private float distance;
    public float minDistance = 1;
    public enum State { CONTROLLED, WAIT, MOVABLE }
    public State GhostState;

    //Objet dans lequel on est rentré en collision avec
    public List<GameObject> CurrentInteraction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        GhostState = State.CONTROLLED;
        anim = transform.GetChild(0).GetComponent<Animator>();
//        FindObjectOfType<SoundManager>().PlaySfx("SpawnGhost");
        FindObjectOfType<Achievement>().UnlockTrueFalseExorcist();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 5);
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
    }

    public void Movable()
    {
        if (!gameManager.controleP1)
        {


            rb.MovePosition(transform.position + ((new Vector3(0, 1, 0) * joystick.Vertical * speed) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed)) * Time.deltaTime);
            if (joystick.Vertical != 0 || joystick.Horizontal != 0)
            {
                anim.SetBool("Walk", true);
                if (joystick.Horizontal < 0)
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
                anim.SetBool("Walk", false);
            }
        }

    }

    public void Controlled()
    {
        distance = Vector2.Distance(Player1.transform.position, transform.position);
        
        if (distance > minDistance)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, MyPlayer.transform.position, speed * Time.deltaTime));
            try
            {
                anim.SetBool("Walk", true);
                Debug.Log("anim");
                if (footP1.gameObject.transform.position.x < footP2.gameObject.transform.position.x)
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
            }
            catch { }
        }
        else
        {
           Wait();
        }
    }

    public void Wait()
    {
        //GhostEffectHUD.SetActive(false);
        //Stay at this position
        
        try
        {
            anim.SetBool("Walk", false);
            if (footP1.gameObject.transform.position.x < footP2.gameObject.transform.position.x)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }

        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.GetChild(0).GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 1))
        {
            if (collision.gameObject.CompareTag("Interactable"))
            {

                CurrentInteraction.Add(collision.gameObject);
                Debug.Log(collision.gameObject.name);
            }

            if (collision.gameObject.CompareTag("creature"))
            {
                FindObjectOfType<Achievement>().UnlockCreature();
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Remove(collision.gameObject);
        }
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
