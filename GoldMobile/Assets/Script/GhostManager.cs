using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;
    public bool isP2;
    public bool cam = false;
    public PlayerManager Player1;

    public GameObject footP1;
    public GameObject footP2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;
        isP2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isP2)
        {
            rb.MovePosition(transform.position + (new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * speed) + (new Vector3(1, 0, 0) * Input.GetAxis("Horizontal") * speed));
            if (Input.GetKeyDown(KeyCode.Space))
                ChangeControl();

        }
        if (footP1.gameObject.transform.position.y > footP2.gameObject.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        }else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

    }

    public void ChangeControl()
    {
        isP2 = false;
        GameManager._instance.ChangeCamera(cam);
        StartCoroutine(WaitToControl());
        IEnumerator WaitToControl()
        {
            yield return new WaitForSeconds(0.2f);
            Player1.isP1 = true;
        }
    }
}
