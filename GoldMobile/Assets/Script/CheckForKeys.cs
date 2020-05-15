using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForKeys : MonoBehaviour
{

    public string DesiredKey;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < collision.gameObject.GetComponent<KeySystem>().Keys.Count; i++)
            {
                if (collision.gameObject.GetComponent<KeySystem>().Keys[i] == DesiredKey)
                {
                    gameObject.SetActive(false);
                }
            }
           
        }
    }
}
