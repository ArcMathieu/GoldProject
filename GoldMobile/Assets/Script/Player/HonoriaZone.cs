using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class HonoriaZone : MonoBehaviour
{
    public GhostManager Honoria;
    public StoryGame storyManager;
    public List<GameObject> CurrentInteraction;
    public Light2D honoriaLight;
    public int compteur;
    //public Text textScore;
    Color32 BaseColor = new Color32(131, 219, 255, 255);
    Color32 DetectionColor = new Color32(0, 170, 255, 255);

    public List<GameObject> Ombres;

    Color Invisible = new Color32(255, 255, 255, 0);
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
                        Ombre.GetComponent<SpriteRenderer>().color = Color32.Lerp(Ombre.gameObject.GetComponent<SpriteRenderer>().color, new Color32(255, 255, 255, 1), 0.05f);
                        if (Ombre.gameObject.GetComponent<SpriteRenderer>().color == Invisible)
                        {
                            Destroy(Ombre.gameObject);
                        }
                    }
                    else
                    {
                        Ombre.gameObject.GetComponent<SpriteRenderer>().color = Color32.Lerp(Ombre.gameObject.GetComponent<SpriteRenderer>().color, Invisible, 0.05f);
                        if (Ombre.gameObject.GetComponent<SpriteRenderer>().color == Invisible)
                        {
                            compteur++;
                            //StartCoroutine(ScoreOmbres());
                            Destroy(Ombre.gameObject);
                        }
                    }
                }
            }
        }
    }

    //IEnumerator ScoreOmbres()
    //{
    //    textScore.text = "hello"/*compteur.ToString() + "/" + Ombres.Count.ToString()*/;
    //    yield return new WaitForSeconds(2);
    //    textScore.text = "";

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dial "je sens quelque chose"
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
            Vibration.Vibrate();
        }

        if (collision.gameObject.CompareTag("Ombres"))
        {
            Ombres.Add(collision.gameObject);
            Vibration.Vibrate(200);
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
