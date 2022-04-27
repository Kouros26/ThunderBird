using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterFuel : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHands;
           GameObject BucketWater;
    bool water = false, followWater = false, hasObject = false;




    void Start()
    {

    }

    void FixedUpdate()
    {
        if (followWater)
        {
            BucketWater.transform.position = playerHands.transform.position;
            water = false;
        }
    }
}
