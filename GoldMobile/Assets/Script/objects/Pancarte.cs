using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancarte : MonoBehaviour
{
    public GameObject number;
    public void setAction()
    {
        number.SetActive(true);
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            number.SetActive(false);

        }
    }
}
