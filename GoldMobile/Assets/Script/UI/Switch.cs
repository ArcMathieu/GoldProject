using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool controlePlayer = false;
    public bool CanSwitchInRoom = false;
    public bool CanSwitchInZone = false;

    public PlayerManager player;
    public GhostManager ghost;
    public GameManager gameManager;

    public GameObject ghostAppears;
    public Zone zone;

    public void DoAction()
    {
        if (!zone.questStart && CanSwitchInRoom)
        {
            zone.questStart = true;
            zone.questEnd = false;
            
        }
        
        if (!controlePlayer)
        {
            StartCoroutine(Waiting());
            IEnumerator Waiting()
            {
                yield return new WaitForSeconds(0.2f);
                player.ChangeControl();
                gameManager.openStep();
                controlePlayer = true;
            }
        }else
        {
            if (CanSwitchInZone)
            {
                StartCoroutine(Waiting());
                IEnumerator Waiting()
                {
                    yield return new WaitForSeconds(0.2f);
                    ghost.ChangeControl();
                    gameManager.openStep();
                    controlePlayer = false;

                }

            }
        }
        
    }
}
