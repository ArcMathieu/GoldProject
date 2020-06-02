using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleJayZ : MonoBehaviour
{
    public bool PlayerBubbled;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().Play("BubbleSpawn", -1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            PlayerBubbled = true;
        }
         
    }
}
