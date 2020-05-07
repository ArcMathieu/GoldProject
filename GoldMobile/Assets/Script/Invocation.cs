using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager ghost;
    public GameObject ghostAppears;
    public bool isAppears = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAppears && collision.gameObject.CompareTag("Player"))
        {
            ghostAppears.SetActive(true);
            isAppears = true;
            player.ChangeControl();
        }
    }
}
