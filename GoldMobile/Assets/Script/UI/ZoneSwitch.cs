using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSwitch : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager gh;
    private bool InZone;
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            InZone = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            InZone = false;

        }

    }
}
