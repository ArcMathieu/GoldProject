using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    private TextMeshPro m_Text;
    private TextContainer m_TextContainer;
    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to an existing TextMeshPro component or Add one if needed.
        m_Text = GetComponent<TextMeshPro>();

        // Get a reference to the text container. Alternatively, you can now use the RectTransform on the text object instead.
        m_TextContainer = GetComponent<TextContainer>();
        m_TextContainer.width = 25f;
        m_TextContainer.height = 3f;

        // Set the point size
        m_Text.fontSize = 24;

        // Set the text
        m_Text.text = "A simple line of text.";
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = "Hello";
        Debug.Log("teeexxxxxte");
    }
}
