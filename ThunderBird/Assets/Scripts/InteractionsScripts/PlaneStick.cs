using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlaneStick : MonoBehaviour
{
    public static float Altitude = 33000;
    public static float AltitudeMax = Altitude;
    [SerializeField] public bool shakingEvent = false;

    private float x, y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += 0.01f;
        if(!shakingEvent)
        {
            if (EventScript.isOccupied)
            {
                x = 0;
                y += 0.05f;
                Altitude += y * y * Time.deltaTime;
                Altitude = Mathf.RoundToInt(Altitude);

                if (Altitude >= AltitudeMax)
                    Altitude = AltitudeMax;

                return;
            }
        }
        if (shakingEvent)
        {
            if (EventScript.isOccupied && Turbulences.coPilotReady)
            {
                x = 0;
                y += 0.05f;
                Altitude += y * y * Time.deltaTime;
                Altitude = Mathf.RoundToInt(Altitude);

                if (Altitude >= AltitudeMax)
                    Altitude = AltitudeMax;

                return;
            }
        }

        y = 0;
        Altitude -= x * x * Time.deltaTime;
        Altitude = Mathf.RoundToInt(Altitude);

        if (Altitude <= 0)
            Altitude = 0;
    }

    public static void Punishment()
    {
        Altitude = Altitude - 1000;
    }
}
