using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HonoriaZone : MonoBehaviour
{
    public GhostManager Honoria;
    public StoryGame storyManager;
    public List<GameObject> CurrentInteraction;
    public Light2D honoriaLight;
    Color BaseColor = new Color(131, 219, 255);
    Color DetectionColor = new Color(131, 170, 255);
    void Update()
    {
        transform.position = Honoria.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Add(collision.gameObject);
            Debug.Log("objProche");
            //honoriaLight.color = Color.Lerp(BaseColor, DetectionColor, Mathf.PingPong(Time.time, 1));
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            CurrentInteraction.Add(collision.gameObject);
            storyManager.DoorToSerre = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GameManager._instance.openStep();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Remove(collision.gameObject);
            Debug.Log("objLoin");
            //honoriaLight.color = Color.Lerp(DetectionColor, BaseColor, Mathf.PingPong(Time.time, 1));
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            CurrentInteraction.Remove(collision.gameObject);
            storyManager.DoorToSerre = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameManager._instance.openStep();
        }
    }


}
