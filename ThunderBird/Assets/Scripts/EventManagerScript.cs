using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    public bool isEventThunderOn = false;
    public static bool isEventShakeOn = false;
    public bool isEventAirOn = false;

    public GameObject Thunder;
    public GameObject Shake;
    public GameObject Air;

    [SerializeField] private GameObject[] doorTriggers;

    [SerializeField] private GameObject cam;
    Animator camShake;

    bool specialTask = false;
    public static bool task = false;
    bool alreadyFire = true;
    bool alreadyFuel = true;
    public static bool alreadyDoor = false;
    bool alreadyPet = true;

    public static bool allDoorsOpen = false;
    public static bool closeCockpit = false;
    public static bool closeKitchen = false;
    public static bool closeEngine = false;

    public PlaneStick planeStickScript;

    private void Start()
    {
        camShake = cam.GetComponent<Animator>();
    }

    void Update()
    {
        if (!specialTask)
        {
            specialTask = true;
            StartCoroutine(WaitForSpecialMission());       
        }

        if (!task)
        {
            task = true;
            StartCoroutine(WaitForMission());
        }

        //DEBUG MISSION
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Turbulences();
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
        planeStickScript.shakingEvent = true;
        camShake.SetBool("Shake", true);
        StartCoroutine(ShakingEvent());
    }

    IEnumerator ShakingEvent()
    {
        yield return new WaitForSeconds(40);
        planeStickScript.shakingEvent = false;
        camShake.SetBool("Shake", false);
        Shake.SetActive(false);
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
        if(mission == 1)
        {
            Fire();
        }
        if (mission == 2)
        {
            Fuel();
        }
        if (mission == 3)
        {
            PetTheDragon();
        }
        if (mission ==4)
        {
            DoorClose();
        }
    }

    void Fire()
    {
        if(!alreadyFire && !alreadyFuel)
        {

        }

        else
        {
            PetTheDragon();
        }
    }

    void Fuel()
    {
        if(!alreadyFuel && !alreadyFire)
        {

        }

        else
        {
            task = false;
            return;
        }
    }

    void PetTheDragon()
    {
        if(!alreadyPet)
        {
            task = false;
            alreadyPet = true;

        }

        else
        {
            DoorClose();
        }
    }

    void DoorClose()
    {
        if(!alreadyDoor && allDoorsOpen)
        {
            task = false;
            alreadyDoor = true;
            int closeSomething = Random.Range(0, 3);
            DoorManagement pickedObject = doorTriggers[closeSomething].GetComponent<DoorManagement>();
            pickedObject.DoorClosing();
        }

        else
        {
            Fuel();
        }
    }
}