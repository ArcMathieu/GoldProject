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
    public Switch switchButton;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            illness.modifyBar(false);
            if (questStart)
            {
                switchButton.CanSwitchInZone = false;
                gh.GhostState = GhostManager.State.MOVABLE;
            }
            else
            {
                
                gh.GhostState = GhostManager.State.WAIT;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostPlayer"))
        {
            illness.modifyBar(true);
            if (player.PlayerState == PlayerManager.State.MOVABLE)
            {
                gh.GhostState = GhostManager.State.CONTROLLED;

            }else if (player.PlayerState == PlayerManager.State.WAIT) {
                gh.GhostState = GhostManager.State.MOVABLE;

            }
            if (!questStart)
            {
                gh.GhostState = GhostManager.State.CONTROLLED;

            }else
            {
                switchButton.CanSwitchInZone = true;
            }
            
        }

    }
}
