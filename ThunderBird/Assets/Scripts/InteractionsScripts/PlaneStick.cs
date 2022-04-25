using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStick : MonoBehaviour
{
    public static float Altitude = 33000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterInteractions.interacting) return;

        Altitude -= 10 * Time.deltaTime;
    }
}
