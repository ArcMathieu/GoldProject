using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{
    public DialogueData dialGhost;
    public DisplayText tdialogue;
    private bool firstTime;

    // Start is called before the first frame update
    void Awake()
    {
        firstTime = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
                
            if (tdialogue.DoneTalking && !firstTime)
            {
                tdialogue.DialPass(dialGhost);
                firstTime = true;
            }
            try
            {
                GetComponent<Animator>().SetTrigger("horsed");
            }
            catch { }
        }
        
            
    }
}
