using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    private Vector2 mouvement;
    public GameManager gameManager;
    private Animator animat;
    public Transform Player;
    public bool detected;
    public float distanceDetect;
    public bool isflip = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        speed = GameManager._instance.playerSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player)
        {
            float distance = (Player.position - transform.position).sqrMagnitude;
            if (distance < distanceDetect * distanceDetect)
            {
                detected = true;
                if (detected == true)
                {
                    lookPlayer();
                    Vector3 direction = Player.position - transform.position;
                    direction.Normalize();
                    mouvement = direction;
                    move(mouvement);
                    

                }
                else
                {
                    
                }
            }
            else
            {
                detected = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(Player.gameObject);
        }
    }

    public void lookPlayer()
    {
        Vector3 flip = transform.localScale;
        flip.z = -1f;

        if(transform.position.x < Player.position.x && !isflip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isflip = true;
        }
        else if (transform.position.x > Player.position.x && isflip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isflip = false;
        }

    }

    public void move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.timeScale));
    }


}
