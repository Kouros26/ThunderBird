using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    public bool isEventThunderOn;
    public bool isEventShakeOn;
    public bool isEventAirOn;

    public GameObject Thunder;
    public GameObject Shake;
    public GameObject Air;

    bool specialTask = false;
    bool task = false;
    bool alreadyFire = false;
    bool alreadyFuel = false;
    bool alreadyDoor = false;
    bool alreadyPet = false;

    void Update()
    {
        if (!specialTask)
        {
            specialTask = true;
            StartCoroutine(WaitForSpecialMission());
        }

        if (!task)
        {
            StartCoroutine(WaitForMission());
        }
    }

    IEnumerator WaitForSpecialMission()
    {
        int random = Random.Range(40, 91);
        yield return new WaitForSeconds(random);
        int eventToPerform = Random.Range(1, 4);
        if(eventToPerform == 1)
        {
            Thunderstorm();
        }
        else if(eventToPerform == 2)
        {
            Turbulences();
        }
        else if(eventToPerform == 3)
        {
            Depressurization();
        }
    }
    void Thunderstorm()
    {
        Thunder.SetActive(true);
        Shake.SetActive(false);
        Air.SetActive(false);
    }

    void Turbulences()
    {
        Shake.SetActive(true);
        Thunder.SetActive(false);
        Air.SetActive(false);
    }

    void Depressurization()
    {
        Air.SetActive(true);
        Thunder.SetActive(false);
        Shake.SetActive(false);
    }

    IEnumerator WaitForMission()
    {
        int random = Random.Range(8, 17);
        yield return new WaitForSeconds(random);
        int mission = Random.Range(1, 5);
    }

    void Fire()
    {

    }

    void Fuel()
    {

    }

    void PetTheDragon()
    {

    }

    void DoorClose()
    {

    }
}