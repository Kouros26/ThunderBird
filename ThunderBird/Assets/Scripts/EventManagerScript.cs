using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    public bool isEventThunderOn = false;
    public static bool isEventShakeOn = false;

    public GameObject Thunder;
    public GameObject Shake;

    [SerializeField] private GameObject dragonUI;
    [SerializeField] private GameObject dragonHitbox;
 
    [SerializeField] private GameObject[] doorTriggers;

    [SerializeField] private GameObject cam;
    Animator camShake;

    bool specialTask = false;
    public static bool task = false;
    bool alreadyFire = true;
    bool alreadyFuel = true;
    public static bool alreadyDoor = false;
    bool alreadyPet = false;

    public static bool allDoorsOpen = false;
    public static bool closeCockpit = false;
    public static bool closeKitchen = false;
    public static bool closeEngine = false;

    public PlaneStick planeStickScript;

    public AudioManagerScript sceneAudio;

    private void Start()
    {
        camShake = cam.GetComponent<Animator>();
        dragonHitbox = GameObject.Find("plaques_chariot");
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
            PetTheDragon();
        }
    }

    IEnumerator WaitForSpecialMission()
    {
        int random = Random.Range(40, 91);
        yield return new WaitForSeconds(random);
        int eventToPerform = Random.Range(1, 3);
        if(eventToPerform == 1)
        {
            Thunderstorm();
        }
        else if(eventToPerform == 2)
        {
            Turbulences();
        }
    }
    void Thunderstorm()
    {
        sceneAudio.clip = sceneAudio.MainAlarm;
        sceneAudio.PlayAudio();
        Thunder.SetActive(true);
        Shake.SetActive(false);
    }

    void Turbulences()
    {
        sceneAudio.clip = sceneAudio.MainAlarm;
        sceneAudio.PlayAudio();
        Shake.SetActive(true);
        Thunder.SetActive(false);
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
            sceneAudio.clip = sceneAudio.MainAlarm;
            sceneAudio.PlayAudio();
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
            sceneAudio.clip = sceneAudio.MainAlarm;
            sceneAudio.PlayAudio();
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
            dragonUI.SetActive(true);
            dragonHitbox.GetComponent<BoxCollider>().enabled = true;
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

    public void DragonFinished()
    {
        alreadyPet = false;
        dragonUI.SetActive(false);
        dragonHitbox.GetComponent<BoxCollider>().enabled = false;
    }
}