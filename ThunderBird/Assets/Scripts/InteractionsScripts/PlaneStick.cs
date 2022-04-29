using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

public class PlaneStick : MonoBehaviour
{
    public static float Altitude = 33000;
    public static float AltitudeMax = Altitude;
    [SerializeField] public bool shakingEvent = false;
    public AudioManagerScript sceneAudio;
    bool once = false;
    public GameObject consoleLights;
    public GameObject warningLights;

    private static float x, y;

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

                if (Altitude < 0)
                {
                    Altitude = 0;
                    SceneManager.LoadScene(2);
                }

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

        if (Altitude < 0)
        {
            Altitude = 0;
            SceneManager.LoadScene(2);
        }
        if (Altitude <= 12000)
        {
           if(!once)
           {
                once = true;
                AudioManagerScript.clip = sceneAudio.AirplaneFall;
                AudioManagerScript.PlayAudio();
                consoleLights.SetActive(false);
                warningLights.SetActive(true);
                StartCoroutine(ClaMerde());
           }
           else
           {
                return;
           }
        }
        if (Altitude > 12000)
        {
            once = false;
            warningLights.SetActive(false);
            consoleLights.SetActive(true);
        }
    }

    public static void Punishment()
    {
        Altitude = Altitude - 5000;
        y = 0;
    }
    IEnumerator ClaMerde()
    {
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        warningLights.SetActive(true);
    }
}
