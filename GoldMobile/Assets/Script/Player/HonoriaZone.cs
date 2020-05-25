using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonoriaZone : MonoBehaviour
{
    public GhostManager Honoria;
    public StoryGame storyManager;

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
            CurrentInteraction.Add(collision.gameObject);
            Debug.Log("collDoor : " + collision.gameObject.name);
            Debug.Log("collDoorChild : " + collision.gameObject.GetComponentInChildren<GameObject>().name);
            storyManager.DoorToSerre = true;
            collision.gameObject.GetComponentInChildren<GameObject>().SetActive(false);
            GameManager._instance.openStep();
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
            CurrentInteraction.Remove(collision.gameObject);
            storyManager.DoorToSerre = false;
            collision.gameObject.GetComponentInChildren<GameObject>().SetActive(true);
            GameManager._instance.openStep();
        }
    }


}
