using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject tpTo;
    public bool canPass = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canPass)
        {
            collision.transform.position = new Vector2(tpTo.transform.position.x, tpTo.transform.position.y - 3);

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
