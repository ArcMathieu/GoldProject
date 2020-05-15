using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject tpTo;
    public bool canPass = false;
    public bool stairs = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canPass)
        {
            if (stairs)
            {
                collision.transform.position = new Vector2(tpTo.transform.position.x, tpTo.transform.position.y-5);
            }
            else
            {
                collision.transform.position = tpTo.transform.position;
            }

            tpTo.SendMessage("CoroutToWait");
        }
    }

    public void CoroutToWait()
    {
        StartCoroutine(WaitToPass());
        IEnumerator WaitToPass()
        {
            canPass = false;
            yield return new WaitForSeconds(1.5f);
            canPass = true;
        }
    }
}
