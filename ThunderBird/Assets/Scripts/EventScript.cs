using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private static GameObject Cockpit1;
    private static GameObject Cockpit2;

    private static GameObject PopUpCockpit;

    private static GameObject Switch;
    private static GameObject PopUpSwitch;

    private static GameObject Engine;
    private static GameObject PopUpFuel;
    private static GameObject PopUpFire;

    public static bool isOccupied = false;
    //public Transform reset;

    private void Start()
    {
        //Engine = GameObject.Find("Moteur");
        //PopUpFuel = GameObject.Find("PopUpFuel");

        Cockpit1 = GameObject.Find("Chaise_g_1");
        Cockpit2 = GameObject.Find("Chaise_g_1 1");
        PopUpCockpit = GameObject.Find("PopUpCockpit");

        //Switch = GameObject.Find("Switch");
        //PopUpSwitch = GameObject.Find("PopUpSwitch");
    }

    #region CockpitMission
    public static void CockpitMission()
    {
        if(!isOccupied)
        {
            //this.gameObject.transform.position = reset.transform.position;
            PopUpCockpit.SetActive(true);
            Cockpit1.GetComponent<BoxCollider>().enabled = true;
            Cockpit2.GetComponent<BoxCollider>().enabled = false;
        }
        else if(isOccupied)
        {
            PopUpCockpit.SetActive(false);
            Cockpit1.GetComponent<BoxCollider>().enabled = false;
            Cockpit2.GetComponent<BoxCollider>().enabled = true;
        }
    }
    #endregion

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
