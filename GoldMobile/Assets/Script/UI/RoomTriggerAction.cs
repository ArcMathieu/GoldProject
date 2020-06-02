using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerAction : MonoBehaviour
{
    public GameObject switchButton;
    public StoryGame storyManager;
    public bool secreteCaveTrappe;
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
            if (!secreteCaveTrappe)
            {
                switchButton.SetActive(false);
            }
        }
    }
}
