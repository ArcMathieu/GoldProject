using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    public Joystick joystick;
    public bool cam = true;
    public bool isP1;
    public GhostManager Player2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        isP1 = true;
    }

    void Update()
    {
        if (isP1)
        {
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * joystick.Vertical * speed) + (new Vector3(1, 0, 0) * joystick.Horizontal * speed));
            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    ChangeControl();
            //}

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
