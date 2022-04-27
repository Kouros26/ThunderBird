using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHitbox : MonoBehaviour
{
    public static GameObject item;
    public static GameObject BucketWater;
    public static GameObject BucketFuel;
    public static GameObject BucketEmpty;

    public static bool interactible;
    public static bool pickable = false, follow = false, hasObject = false;
    public static bool dragon = false;
    public static bool Engine1 = false;
    public static bool Engine2 = false;
    public static bool water = false;
    public static bool fuel = false;
    public static bool emptybucket = false;
    public static bool fuelpumps = false;

    public bool OnDoor;
    public bool includeChildren = true;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Pumps":
                fuelpumps = true;
                break;

            case "EmptyBucket":
                emptybucket = true;
                BucketEmpty = other.gameObject;
                break;

            case "Fuel":
                fuel = true;
                BucketFuel = other.gameObject;
                break;

            case "Water":
                water = true;
                BucketWater = other.gameObject;
                break;

            case "Interactible":
                interactible = true;
                break;

            case "pickup":
                pickable = true;
                item = other.gameObject;
                break;

            case "Dragon":
                              Debug.Log("in");
                dragon = true;
                break;

            case "Engine1":
                Engine1 = true;
                break;

            case "Engine2":
                Engine2 = true;
                break;

            case "Door":
                OnDoor = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Pumps":
                fuelpumps = false;
                break;

            case "EmptyBucket":
                emptybucket = false;
                break;

            case "Fuel":
                fuel = false;
                break;

            case "Water":
                water = false;
                break;

            case "pickup":
                pickable = false;
                break;

            case "Engine1":
                Engine1 = false;
                break;

            case "Engine2":
                Engine2 = false;
                break;

            case "Dragon":
                Debug.Log("out");

                dragon = false;
                break;

            case "Door":
                OnDoor = false;
                break;
        }

        interactible = false;
    }
}
