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

    void Update()
    {
        if(isEventThunderOn == true)
        {
            Thunder.SetActive(true);
            Shake.SetActive(false);
            Air.SetActive(false);
        }
        else
        {
            Thunder.SetActive(false);
        }

        if (isEventShakeOn == true)
        {
            Shake.SetActive(true);
            Thunder.SetActive(false);
            Air.SetActive(false);
        }
        else
        {
            Shake.SetActive(false);
        }

        if (isEventAirOn == true)
        {
            Air.SetActive(true);
            Thunder.SetActive(false);
            Shake.SetActive(false);
        }
        else
        {
            Air.SetActive(false);
        }
    }
}
