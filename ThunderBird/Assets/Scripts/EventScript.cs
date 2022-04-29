using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private static GameObject Cockpit1;
    private static GameObject Cockpit2;

    private static GameObject PopUpCockpit;

    public static bool isOccupied = false;

    private void Start()
    {
        Cockpit1 = GameObject.Find("Chaise_g_1");
        Cockpit2 = GameObject.Find("Chaise_g_1 1");
        PopUpCockpit = GameObject.Find("PopUpCockpit");
    }

    #region CockpitMission
    public static void CockpitMission()
    {
        if (!isOccupied)
        {
            //this.gameObject.transform.position = reset.transform.position;
            PopUpCockpit.SetActive(true);
            Cockpit1.GetComponent<BoxCollider>().enabled = true;
            Cockpit2.GetComponent<BoxCollider>().enabled = false;
        }
        else if (isOccupied)
        {
            PopUpCockpit.SetActive(false);
            Cockpit1.GetComponent<BoxCollider>().enabled = false;
            Cockpit2.GetComponent<BoxCollider>().enabled = true;
        }
    }
    #endregion
}
