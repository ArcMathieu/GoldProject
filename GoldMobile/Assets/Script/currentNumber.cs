using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currentNumber : MonoBehaviour
{

    public int number;
    public TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "" + number;

    }



}
