using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    public Joystick joystick;
    private bool cam = true;
    public bool isP1;
    public GhostManager Player2;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        isP1 = true;
    }

    void Update()
    {
        if (isP1)
        {
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * joystick.Vertical * speed) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed));

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

    public void ChangeControl()
    {
        isP1 = false;
        GameManager._instance.ChangeCamera(cam);
        StartCoroutine(WaitToControl());
        IEnumerator WaitToControl()
        {
            yield return new WaitForSeconds(0.2f);
            Player2.isP2 = true;
        }
    }
}
