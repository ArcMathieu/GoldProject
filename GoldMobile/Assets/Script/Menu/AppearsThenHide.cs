using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearsThenHide : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(waitToHide());
        IEnumerator waitToHide()
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}
