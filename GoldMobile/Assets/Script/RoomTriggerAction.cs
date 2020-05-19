using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerAction : MonoBehaviour
{
    public GameObject switchButton;
    public StoryGame storyManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !storyManager.Tuto)
        {
            switchButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchButton.SetActive(false);
            //if (!GameManager._instance.controleP1)
            //{
            //    GameManager._instance.controleP1 = true;
            //    GameManager._instance.ChangeState();
            //    GameManager._instance.ChangeCamera(true);
            //}
        }
    }
}
