using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private GameObject Cockpit1;
    private GameObject Cockpit2;
    private GameObject PopUpCockpit;

    private GameObject Switch;
    private GameObject PopUpSwitch;

    private GameObject Engine;
    private GameObject PopUpFuel;
    private GameObject PopUpFire;

    //public bool engineactif;

    private void Start()
    {
        Engine = GameObject.Find("Moteur");
        PopUpFuel = GameObject.Find("PopUpFuel");

        Cockpit1 = GameObject.Find("Siege_39_low");
        Cockpit2 = GameObject.Find("Siege_39_low 1");
        PopUpCockpit = GameObject.Find("PopUpCockpit");

        Switch = GameObject.Find("Switch");
        PopUpSwitch = GameObject.Find("PopUpSwitch");
    }

    //Pour check si le script marche
   /* public void Update()
    {
        if (engineactif == true)
        {
            CockpitMission();
        }
        else
        {
            CockpitMissionOff();
        }
    }*/

    public void CockpitMission()
    {
        PopUpCockpit.SetActive(true);
        Cockpit1.GetComponent<BoxCollider>().enabled = true;
    }
    public void CockpitMissionOff()
    {
        PopUpCockpit.SetActive(false);
        Cockpit1.GetComponent<BoxCollider>().enabled = false;
    }

    public void FuelMission()
    {
        PopUpFuel.SetActive(true);
        Engine.GetComponent<BoxCollider>().enabled = true;
    }

    public void FuelMissionOff()
    {
        PopUpFuel.SetActive(false);
        Engine.GetComponent<BoxCollider>().enabled = false;
    }

    public void FireMission()
    {
        PopUpFire.SetActive(true);
        Engine.GetComponent<BoxCollider>().enabled = true;
    }

    public void FireMissionOff()
    {
        PopUpFire.SetActive(false);
        Engine.GetComponent<BoxCollider>().enabled = false;
    }

    public void SwitchMission()
    {
        PopUpSwitch.SetActive(true);
        Switch.GetComponent<BoxCollider>().enabled = true;
    }

    public void SwitchMissionOff()
    {
        PopUpSwitch.SetActive(false);
        Switch.GetComponent<BoxCollider>().enabled = false;
    }
}
