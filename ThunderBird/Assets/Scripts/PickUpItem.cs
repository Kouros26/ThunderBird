using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHands;
    GameObject item;
    bool pickable = false, follow = false, hasObject = false;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if(follow)
        {
            item.transform.position = playerHands.transform.position;
            pickable = false;
        }
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (!hasObject)
        {
            if(pickable)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                follow = true;
                hasObject = true;
            }
            else
            {
                return;
            }
        }
        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            follow = false;
            hasObject = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {
            pickable = true;
            item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pickup")
        {
            pickable = false;
        }
    }
}
