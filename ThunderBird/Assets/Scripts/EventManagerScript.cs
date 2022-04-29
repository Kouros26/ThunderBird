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
    public bool thunderResolved = false;

    public static bool allDoorsOpen = false;
    public static bool closeCockpit = false;
    public static bool closeKitchen = false;
    public static bool closeEngine = false;

    public PlaneStick planeStickScript;
    public GameObject Eclair;
    public GameObject normalLights;
    public GameObject lightsOut;
    public GameObject powerOutUI;
    public GameObject unplugged;
    public GameObject altitude;
    public GameObject engineTrigger;

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
            Thunderstorm();
        }
    }

    IEnumerator WaitForSpecialMission()
    {
        int random = Random.Range(40, 91);
        yield return new WaitForSeconds(random);
        int eventToPerform = Random.Range(1, 3);
        if(eventToPerform == 1 && isEventThunderOn)
        {
            isEventThunderOn = true;
            Thunderstorm();
        }
        else if(eventToPerform == 2)
        {
            Turbulences();
        }
    }
    void Thunderstorm()
    {
        StartCoroutine(StopLightning());
        AudioManagerScript.clip = sceneAudio.ThunderClap;
        AudioManagerScript.audioPlane.volume = 0.5f;
        AudioManagerScript.PlayAudio();
        StartCoroutine(AfterLightningActivate());
        Thunder.SetActive(true);
        specialTask = false;
    }

    public void CheckForThunderFinish()
    {
        AudioManagerScript.clip = sceneAudio.Switch;
        AudioManagerScript.audioPlane.volume = 0.8f;
        AudioManagerScript.PlayAudio();

        isEventThunderOn = false;
        Thunder.SetActive(false);
        normalLights.SetActive(true);
        lightsOut.SetActive(false);
        powerOutUI.SetActive(false);
        unplugged.SetActive(false);
        altitude.SetActive(true);
        engineTrigger.SetActive(false);
    }

    IEnumerator StopLightning()
    {
        yield return new WaitForSeconds(0.04f);
        Eclair.SetActive(true);


        yield return new WaitForSeconds(0.05f);
        Eclair.SetActive(false);

        yield return new WaitForSeconds(0.012f);
        Eclair.SetActive(true);

        yield return new WaitForSeconds(0.013f);
        Eclair.SetActive(false);

        yield return new WaitForSeconds(0.024f);
        Eclair.SetActive(true);

        yield return new WaitForSeconds(0.025f);
        Eclair.SetActive(false);
    }

    IEnumerator AfterLightningActivate()
    {
        yield return new WaitForSeconds(1);
        AudioManagerScript.clip = sceneAudio.BlackOut;
        AudioManagerScript.audioPlane.volume = 1;
        AudioManagerScript.PlayAudio();
        normalLights.SetActive(false);
        lightsOut.SetActive(true);
        powerOutUI.SetActive(true);
        unplugged.SetActive(true);
        altitude.SetActive(false);
        engineTrigger.SetActive(true);
    }

    void Turbulences()
    {
        AudioManagerScript.clip = sceneAudio.MainAlarm;
        AudioManagerScript.audioPlane.volume = 0.2f;
        AudioManagerScript.PlayAudio();
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
        specialTask = false;
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
            AudioManagerScript.clip = sceneAudio.MainAlarm;
            AudioManagerScript.PlayAudio();
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
            AudioManagerScript.clip = sceneAudio.MainAlarm;
            AudioManagerScript.PlayAudio();
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