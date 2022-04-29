using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMaintenance : MonoBehaviour
{
    public EventManagerScript eventManagerScript;
    public CharacterInteractions characterInteractionsScript;

    private void OnTriggerEnter(Collider other)
    {
        characterInteractionsScript = other.GetComponent<CharacterInteractions>();
        if(other.tag == "Player")
        {
            if (eventManagerScript.waterRequired)
            {
                if(eventManagerScript.requirement == 1)
                {
                    eventManagerScript.requirement = 0;
                    eventManagerScript.FireExtinguished();
                    characterInteractionsScript.Drop();
                    characterInteractionsScript = null;
                }
                else
                {
                    return;
                    //DEATH
                }
            }
            if(eventManagerScript.fuelRequired)
            {
                if(eventManagerScript.requirement == 2)
                {
                    eventManagerScript.requirement = 0;
                    eventManagerScript.FuelReplenished();
                    characterInteractionsScript.Drop();
                    characterInteractionsScript = null;
                }
                else
                {
                    return;
                    //DEATH
                }
            }
        }
    }
}
