using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkJayZ : MonoBehaviour
{
    private GameObject Player;
    public GameObject CrossJayZ;

    private float Timer;
    public float TimerDuration;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Timer = TimerDuration;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void JayZsChilling()
    {

    }
    public void JayZsAttack2()
    {

    }

    public void AttackCrossJayZ()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = TimerDuration;
            Instantiate(CrossJayZ, Player.transform.position, Quaternion.identity);
        }
    }
}
