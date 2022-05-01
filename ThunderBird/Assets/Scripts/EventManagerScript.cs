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
    //[SerializeField] private GameObject dragonHitbox;
 
    [SerializeField] private GameObject[] doorTriggers;

    [SerializeField] private GameObject cam;
    Animator camShake;

    bool specialTask = false;
    public static bool task = false;
    bool alreadyFire = false;
    bool alreadyFuel = false;
    public static bool alreadyDoor = false;
    public bool alreadyPet = false;
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

    public GameObject fireUI;
    public GameObject fuelUI;
    public GameObject tankTrigger;
    public bool waterRequired = false;
    public bool fuelRequired = false;
    public int requirement = 0;
    public GameObject water;
    public GameObject fuel;
    bool startedTime;
    float timer;

    public AudioManagerScript sceneAudio;

    private void Start()
    {
        camShake = cam.GetComponent<Animator>();
        //dragonHitbox = GameObject.Find("plaques_chariot");
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
            //Thunderstorm();
            Turbulences();
            //PetTheDragon();
        }

        //if(!alreadyDoor)
        //{
        //    DoorClose();
        //}

        if(startedTime)
        {
            timer += Time.deltaTime;
            if(timer > 12)
            {
                PlaneStick.Punishment();
                startedTime = false;
                timer = 0;
            }
        }
    }

    IEnumerator WaitForSpecialMission()
    {
        int random = Random.Range(20, 40);
        yield return new WaitForSeconds(random);
        int eventToPerform = Random.Range(1, 3);
        if(eventToPerform == 1 && !isEventThunderOn)
        {
            isEventThunderOn = true;
            Thunderstorm();
        }
        if(eventToPerform == 2)
        {
            Turbulences();
        }
    }
    void Thunderstorm()
    {
        StartCoroutine(StopLightning());
        AudioManagerScript.clip = sceneAudio.ThunderClap;
        AudioManagerScript.PlayAudio();
        StartCoroutine(AfterLightningActivate());
        Thunder.SetActive(true);
        specialTask = false;
    }

    public void CheckForThunderFinish()
    {
        AudioManagerScript.clip = sceneAudio.Switch;
        AudioManagerScript.PlayAudio();
        startedTime = false;
        timer = 0;
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
        AudioManagerScript.PlayAudio();
        normalLights.SetActive(false);
        lightsOut.SetActive(true);
        powerOutUI.SetActive(true);
        unplugged.SetActive(true);
        altitude.SetActive(false);
        engineTrigger.SetActive(true);
        startedTime = true;
        //StartCoroutine(BlackoutTime());

    }

    void Turbulences()
    {
        //isEventShakeOn = true;
        AudioManagerScript.clip = sceneAudio.MainAlarm;
        AudioManagerScript.PlayAudio();
        Shake.SetActive(true);
        //Thunder.SetActive(false);
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
        //isEventShakeOn = false;
        specialTask = false;
    }

    IEnumerator WaitForMission()
    {
        int random = Random.Range(8, 15);
        yield return new WaitForSeconds(random);
        int mission = Random.Range(1, 5);
        int secondMission = Random.Range(1, 5);
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
        if (secondMission == 1)
        {
            Fire();
        }
        if (secondMission == 2)
        {
            Fuel();
        }
        if (secondMission == 3)
        {
            PetTheDragon();
        }
        if (secondMission == 4)
        {
            DoorClose();
        }
    }

    void Fire()
    {
        if(!alreadyFire && !alreadyFuel)
        {
            alreadyFire = true;
            task = false;
            AudioManagerScript.clip = sceneAudio.FireSoundEffect;
            AudioManagerScript.PlayAudio();
            fireUI.SetActive(true);
            tankTrigger.SetActive(true);
            waterRequired = true;
            startedTime = true;
            //StartCoroutine(FireTime());
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
            alreadyFuel = true;
            task = false;
            AudioManagerScript.clip = sceneAudio.LowFuel;
            AudioManagerScript.PlayAudio();
            fuelUI.SetActive(true);
            tankTrigger.SetActive(true);
            fuelRequired = true;
            startedTime = true;
            //StartCoroutine(FuelTime());
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
            AudioManagerScript.clip = sceneAudio.DragonNotContent;
            AudioManagerScript.PlayAudio();
            dragonUI.SetActive(true);
            startedTime = true;
            //StartCoroutine(DragonTime());
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
        AudioManagerScript.clip = sceneAudio.DragonContent;
        AudioManagerScript.PlayAudio();
        startedTime = false;
        timer = 0;
    }

    public void FireExtinguished()
    {
        fireUI.SetActive(false);
        tankTrigger.SetActive(false);
        waterRequired = false;
        alreadyFire = false;
        startedTime = false;
        timer = 0;
        AudioManagerScript.audioPlane.Stop();
    }

    public void FuelReplenished()
    {
        fuelUI.SetActive(false);
        tankTrigger.SetActive(false);
        fuelRequired = false;
        alreadyFuel = false;
        startedTime = false;
        timer = 0;
    }

    public void Fill()
    {
        if (CharacterInteractions.fillFuel)
        {
            fuel.SetActive(true);
        }
        else if(CharacterInteractions.fillWater)
        {
            water.SetActive(true);
        }
        else
        {
            fuel.SetActive(false);
            water.SetActive(false);
        }
    }

    //IEnumerator FireTime()
    //{
    //    yield return new WaitForSeconds(15);
    //    if(waterRequired == true)
    //    {
    //        PlaneStick.Punishment();
    //        FireExtinguished();
    //    }
    //}

    //IEnumerator FuelTime()
    //{
    //    yield return new WaitForSeconds(15);
    //    if (fuelRequired == true)
    //    {
    //        PlaneStick.Punishment();
    //        FuelReplenished();
    //    }
    //}

    //IEnumerator DragonTime()
    //{
    //    yield return new WaitForSeconds(15);
    //    if (alreadyPet == true)
    //    {
    //        PlaneStick.Punishment();
    //        DragonFinished();
    //    }
    //}

    //IEnumerator BlackoutTime()
    //{
    //    yield return new WaitForSeconds(10);
    //    if (isEventThunderOn == true)
    //    {
    //        PlaneStick.Punishment();
    //        CheckForThunderFinish();
    //    }
    //}
}