using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
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
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * speed) + (new Vector3(1, 0, 0) * Input.GetAxis("Horizontal") * speed));
            //if (Input.GetKeyDown(KeyCode.Space))
            //    ChangeControl();

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
