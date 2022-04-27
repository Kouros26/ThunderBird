using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHibox : MonoBehaviour
{
    private bool Player;
    private bool pickupWater;

    public Spawning spawningScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WaterInHand()
    {
        Player = spawningScript.players[0].GetComponentInChildren<HandHitbox>().OnDoor;

        if (Player && pickupWater)
        {
            Debug.Log("jaieaunow");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Water":
                pickupWater = true;
                break;
           
            case "Player":
                pickupWater = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Water":
                pickupWater = false;
                break;

            case "Player":
                pickupWater = false;
                break;
        }
    }

}
