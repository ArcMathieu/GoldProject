using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Rect rect;
    public int InventorySize;
    [HideInInspector] public GameObject[] caseList;
    public GameObject slotPrefab;
    public int slotSize;
    public bool isP1 = false;

    void Start()
    {
        //slotSize = Mathf.Min(Screen.width / (InventorySize * InventorySize), Screen.height / (InventorySize * InventorySize));
        CreateGrid();
        DrawSlots();
    }

    void CreateGrid()
    {
        for (int i = 0; i < InventorySize * InventorySize; i++)
        {
            caseList[i] = slotPrefab;
            caseList[i].GetComponent<RectTransform>().sizeDelta = new Vector2(InventorySize, InventorySize);
        }
    }
    void DrawSlots()
    {
        for (int i = 0; i < caseList.Length; i++)
        {
            int xPos = i % InventorySize;
            int yPos = i / InventorySize;
            Vector3 position;
            if (isP1)
            {
                position = new Vector3(slotSize * (xPos - (InventorySize - 1) / 2) - Screen.width / 3, -(slotSize * (yPos - (InventorySize - 1) / 2)) + Screen.height / 4, 0);
            } else
            {
                position = new Vector3(slotSize * (xPos - (InventorySize - 1) / 2) + Screen.width / 3, -(slotSize * (yPos - (InventorySize - 1) / 2)) + Screen.height / 4, 0);
            }

            transform.parent.position = new Vector3(0, 0, 0);
            Instantiate(caseList[i], position, Quaternion.identity, transform);
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector3.back);
            for (int i = 0; i < caseList.Length; i++)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Slots>() != null && touch.phase == TouchPhase.Began)
                    {
                        hit.collider.GetComponent<Slots>().ChangeColor();

                    }
                }
            }
        }
    }
}
