using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject tpTo;
    public GameObject ghost;
    public bool canPass = false;
    public bool stairs = false;
    public bool ghostFollowing = false;

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
            if (ghostFollowing)
            {
                ghost.transform.position = new Vector2(collision.transform.position.x +0.5f, collision.transform.position.y + 0.5f);
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
