using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHitbox : MonoBehaviour
{
    public static GameObject item;

    public static bool interactible;
    public static bool pickable = false, follow = false, hasObject = false;
    public static bool dragon = false;
    public static bool Engine1 = false;
    public static bool Engine2 = false;

    public  bool includeChildren = true;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Interactible":
                interactible = true;
                break;

            case "pickup":
                pickable = true;
                item = other.gameObject;
                break;

            case "Dragon":
                dragon = true;
                break;

            case "Engine1":
                print("Engine_1");
                Engine1 = true;
                break;

            case "Engine2":
                print("Engine_2");
                Engine2 = true;
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "pickup":
                pickable = false;
                break;

            case "Engine1":
                Engine1 = false;
                break;

            case "Engine2":
                Engine2 = false;
                break;
        }

        interactible = false;
    }
}
