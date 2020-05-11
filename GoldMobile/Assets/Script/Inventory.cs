using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Rect rect;
    public int gridSize;
    [HideInInspector] public Button[] buttonList;
    public GameObject buttonPrefab;
    public int buttonSize;

    void Start()
    {
        buttonSize = Mathf.Min(Screen.width / (gridSize * gridSize) * 2, Screen.height / (gridSize * gridSize) * 2);
        //CreateGrid();

    }

    //void CreateGrid()
    //{
    //    for (int i = 0; i < gridSize * gridSize; i++)
    //    {
    //        buttonList[i] = buttonPrefab.GetComponent<Button>();
    //        //Instantiate(buttonList[i]);
    //        buttonList[i].GetComponent<RectTransform>().sizeDelta = new Vector2(buttonSize, buttonSize);
    //    }
    //}
    //void DrawButtons()
    //{
    //    for (int i = 0; i < buttonList.Length; i++)
    //    {
    //        int xPos = i % gridSize;
    //        int yPos = i / gridSize;

    //        Vector3 position = new Vector3(buttonSize * (xPos - (gridSize - 1) / 2), -(buttonSize * (yPos - (gridSize - 1) / 2)), 0);
    //        transform.parent.position = new Vector3(0, 0, 0);
    //        Instantiate(buttonList[i], position, Quaternion.identity, transform);
    //        //buttonList[i].GetComponent<RectTransform>().position = position;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
