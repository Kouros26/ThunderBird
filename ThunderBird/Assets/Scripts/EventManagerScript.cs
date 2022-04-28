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

    [SerializeField] private GameObject objCockpit, objTwoCockpit;
    [SerializeField] private GameObject LightOneCockpit, LightTwoCockpit, GroundOneCockpit, GroundTwoCockpit;
    [SerializeField] private GameObject TWOLightOneCockpit, TWOLightTwoCockpit, TWOGroundOneCockpit, TWOGroundTwoCockpit;
    [SerializeField] private GameObject CockpitLock;

    [SerializeField] private GameObject objKitchen, objTwoKitchen;
    [SerializeField] private GameObject LightOneKitchen, LightTwoKitchen, GroundOneKitchen, GroundTwoKitchen;
    [SerializeField] private GameObject TWOLightOneKitchen, TWOLightTwoKitchen, TWOGroundOneKitchen, TWOGroundTwoKitchen;
    [SerializeField] private GameObject KitchenLock;

    [SerializeField] private GameObject objEngine, objTwoEngine;
    [SerializeField] private GameObject LightOneEngine, LightTwoEngine, GroundOneEngine, GroundTwoEngine;
    [SerializeField] private GameObject TWOLightOneEngine, TWOLightTwoEngine, TWOGroundOneEngine, TWOGroundTwoEngine;
    [SerializeField] private GameObject EngineLock;

    Animator anim1, anim2;

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

        if(Input.GetKeyDown(KeyCode.Y))
        {
            DoorClose();
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
            PetTheDragon();
        }
    }

    void PetTheDragon()
    {
        if(!alreadyPet)
        {

        }

        else
        {
            DoorClose();
        }
    }

    void DoorClose()
    {
        if(!alreadyDoor)
        {
            alreadyDoor = true;
            int closeSomething = Random.Range(0, 3);
            print(closeSomething);
            if(closeSomething == 0)
            {
                anim1 = objCockpit.GetComponent<Animator>();
                anim2 = objTwoCockpit.GetComponent<Animator>();
                anim1.SetTrigger("Close");
                anim2.SetTrigger("Close");
                CockpitLock.SetActive(true);

                LightTwoCockpit.SetActive(false);
                LightOneCockpit.SetActive(true);
                GroundTwoCockpit.SetActive(false);
                GroundOneCockpit.SetActive(true);

                TWOLightTwoCockpit.SetActive(false);
                TWOLightOneCockpit.SetActive(true);
                TWOGroundTwoCockpit.SetActive(false);
                TWOGroundOneCockpit.SetActive(true);
            }

            else if (closeSomething == 1)
            {
                anim1 = objKitchen.GetComponent<Animator>();
                anim2 = objTwoKitchen.GetComponent<Animator>();
                anim1.SetTrigger("Close");
                anim2.SetTrigger("Close");
                KitchenLock.SetActive(true);

                LightTwoKitchen.SetActive(false);
                LightOneKitchen.SetActive(true);
                GroundTwoKitchen.SetActive(false);
                GroundOneKitchen.SetActive(true);

                TWOLightTwoKitchen.SetActive(false);
                TWOLightOneKitchen.SetActive(true);
                TWOGroundTwoKitchen.SetActive(false);
                TWOGroundOneKitchen.SetActive(true);
            }

            else if (closeSomething == 2)
            {
                anim1 = objEngine.GetComponent<Animator>();
                anim2 = objTwoEngine.GetComponent<Animator>();
                anim1.SetTrigger("Close");
                anim2.SetTrigger("Close");
                EngineLock.SetActive(true);

                LightTwoEngine.SetActive(false);
                LightOneEngine.SetActive(true);
                GroundTwoEngine.SetActive(false);
                GroundOneEngine.SetActive(true);

                TWOLightTwoEngine.SetActive(false);
                TWOLightOneEngine.SetActive(true);
                TWOGroundTwoEngine.SetActive(false);
                TWOGroundOneEngine.SetActive(true);
            }
        }

        else
        {
            Fuel();
        }
    }
}