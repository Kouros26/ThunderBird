using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaressTheDragon : MonoBehaviour
{
    public ParticleSystem heart;
    public bool includeChildren = true;
    bool dragon = false;

    void Start()
    {
        heart.Stop(includeChildren);
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (dragon)
        {
            heart.Play(includeChildren);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {            
            dragon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            dragon = false;
        }
    }
}
