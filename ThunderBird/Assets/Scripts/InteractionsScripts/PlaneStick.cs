using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlaneStick : MonoBehaviour
{
    public static float Altitude = 33000;
    public static float AltitudeMax = Altitude;

    private float x, y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += 0.003f;

        if (EventScript.isOccupied)
        {
            x = 0;
            y += 0.005f;
            Altitude += y * y * Time.deltaTime;

            if (Altitude >= AltitudeMax)
                Altitude = AltitudeMax;

            return;
        }

        y = 0;
        Altitude -= x * x * Time.deltaTime;

        if (Altitude <= 0)
            Altitude = 0;
    }

    void Punishment()
    {
        Altitude = Altitude - 1000;
    }
}
