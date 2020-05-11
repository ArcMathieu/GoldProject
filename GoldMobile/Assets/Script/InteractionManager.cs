using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public bool isPressedButton = false;
    public bool but = false;
    public GameObject touchPosition;
    public Collider2D buttonB;

    private void Update()
    {

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //if (hit.collider == buttonB) Debug.Log("Button B was pressed");
            touchPosition.SetActive(true);
            touchPosition.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.transform.position = new Vector3(touchPosition.transform.position.x, touchPosition.transform.position.y, -2);
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    touchPosition.SetActive(false);

                    break;


                case TouchPhase.Stationary:
                    break;
            }

        }

    }
    
    public void IsPressed()
    {
        if(isPressedButton == false)
        {
            isPressedButton = true;
        }
        
    }
    public void IsNotPressed()
    {
        isPressedButton = false;
    }


    //private void Update()
    //{
    //    //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

    //    //foreach (Touch touch in Input.touches)
    //    //{

    //    //    //Ray2D ray = Camera.main.ScreenPointToRay(touch.position);

    //    //    //if (Physics2D.Raycast(ray, hit))
    //    //    //{
    //    //    //    if (hit.collider == buttonB) Debug.Log("Button B was pressed");
    //    //    //}
    //    //}
    //    if (Input.touchCount > 0)
    //    {
    //          Touch touch = Input.GetTouch(0);
    //        Debug.Log("fr");
    //    }
    //}



    //Ray ray;
    //public Collider2D selfCol;

    //void Start()
    //{
    //    selfCol = gameObject.GetComponent<Collider2D>();
    //}

    //void Update()
    //{
    //    // detect your touches in your for loop... I assume the current touch is stored in myTouch
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        ray = Camera.main.ScreenPointToRay(touch.position);
    //        if (touch.phase == TouchPhase.Began)
    //        {

    //            Debug.Log("touch");
    //            if (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)) == selfCol)
    //            {
    //                // This button was touched this frame
    //                Debug.Log("Hit Something");
    //            }

    //        }
    //    }
    //    for (int i = 0; i < Input.touchCount; i++)
    //    {
    //        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

    //        Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            Debug.Log("touching");


    //        }
    //    }
    //}






}
