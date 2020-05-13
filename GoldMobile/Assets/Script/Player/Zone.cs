using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager gh;
    public bool questEnd;
    public bool questStart;
    public MentaBar illness;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            if (questStart)
            {

                //illness decrease
                illness.modifyBar(false);

                if (questEnd)
                {
                    gh.GhostState = GhostManager.State.WAIT;
                }
                else gh.GhostState = GhostManager.State.MOVABLE;
            }
            else
            {
                illness.modifyBar(false);
                gh.GhostState = GhostManager.State.WAIT;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            if (questStart)
            {
                //Illness start increase
                illness.modifyBar(true);
            }
            else
            {
                illness.modifyBar(false);
                gh.GhostState = GhostManager.State.CONTROLLED;
            }
        }

    }
}
