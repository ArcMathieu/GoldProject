﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public bool isPressedButton = false;

    private void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector3.back);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Button>() != null && touch.phase == TouchPhase.Began)
                {
                    hit.collider.GetComponent<Button>().onClick();

                }

                if (!isPressedButton)
                {

                    if (hit.collider.GetComponent<Switch>() != null && touch.phase == TouchPhase.Began)
                    {
                        hit.collider.GetComponent<Switch>().DoAction();

                    }
                    isPressedButton = true;
                    waitForFrame();
                }
            }
        }

    }

    public void waitForFrame()
    {
        StartCoroutine(waitBeforePushAgain());
        IEnumerator waitBeforePushAgain()
        {
            yield return new WaitForSeconds(1.5f);
            isPressedButton = false;
        }
    }

}
