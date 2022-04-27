using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaressTheDragon : MonoBehaviour
{
    public ParticleSystem heart;
    public bool includeChildren = true;
    bool dragon = false, love = false;

    void Start()
    {

    }

    //void FixedUpdate()

    //{
    //    if (love)
    //    {
    //        heart.Play(includeChildren);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (love)
        {
                Debug.Log("LOVEACTIVITED");
            heart.Play(includeChildren);
        }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            heart.Stop(includeChildren);
        }
    }

}
