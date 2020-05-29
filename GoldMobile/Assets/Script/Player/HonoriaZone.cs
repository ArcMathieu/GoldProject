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
    Color32 BaseColor = new Color32(131, 219, 255, 255);
    Color32 DetectionColor = new Color32(0, 170, 255, 255);

    public List<GameObject> Ombres;

    Color Invisible = new Color(255, 255, 255, 0);
    void Update()
    {
        transform.position = Honoria.transform.position;

        if (Ombres.Count != 0)
        {
            foreach (GameObject Ombre in Ombres)
            {
                if (Ombre == null)
                {
                    Ombres.Remove(Ombre);
                }
                else
                {
                    Debug.Log("hid");
                    if (!Ombre.GetComponent<OmbresBool>().CollidesWithHonoria)
                    {
                        Ombre.GetComponent<SpriteRenderer>().color = Color.Lerp(Ombre.gameObject.GetComponent<SpriteRenderer>().color, new Color(255, 255, 255, 1), 0.05f);
                    }
                    else
                    {
                        Ombre.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Ombre.gameObject.GetComponent<SpriteRenderer>().color, Invisible, 0.05f);
                        if (Ombre.gameObject.GetComponent<SpriteRenderer>().color == Invisible)
                        {
                            Destroy(Ombre.gameObject);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Add(collision.gameObject);
            Debug.Log("objProche");
            //honoriaLight.color = Color32.Lerp(BaseColor, DetectionColor, Mathf.PingPong(Time.time, 1));
            //honoriaLight.intensity = Mathf.Lerp(1.89f, 2.5f, Mathf.PingPong(Time.time, 1));
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            CurrentInteraction.Add(collision.gameObject);
            storyManager.DoorToSerre = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GameManager._instance.openStep();
        }

        if (collision.gameObject.CompareTag("Ombres"))
        {
            Ombres.Add(collision.gameObject);
            collision.gameObject.GetComponent<OmbresBool>().CollidesWithHonoria = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            CurrentInteraction.Remove(collision.gameObject);
            Debug.Log("objLoin");
            //honoriaLight.color = Color.Lerp(DetectionColor, BaseColor, Mathf.PingPong(Time.time, 1));
            //honoriaLight.intensity = Mathf.Lerp(2.5f, 1.89f, Mathf.PingPong(Time.time, 1));
        }
        if (collision.gameObject.CompareTag("SpecialDoor"))
        {
            CurrentInteraction.Remove(collision.gameObject);
            storyManager.DoorToSerre = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameManager._instance.openStep();
        }
        if (collision.gameObject.CompareTag("Ombres"))
        {
            collision.gameObject.GetComponent<OmbresBool>().CollidesWithHonoria = false;
        }
    }


}
