using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonoriaZone : MonoBehaviour
{
    public GhostManager Honoria;
    public StoryGame storyManager;
    public GameObject Door;

    public List<GameObject> CurrentInteraction;

    void Update()
    {
        transform.position = Honoria.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("objProche");
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            Debug.Log("PorteOuverte");
            storyManager.DoorToSerre = true;
            GameManager._instance.openStep();
            collision.gameObject.SetActive(false);
            //Door.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("objLoin");
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            storyManager.DoorToSerre = false;
            GameManager._instance.openStep();
            collision.gameObject.SetActive(true);

        }
    }


}
