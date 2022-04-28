using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaressTheDragon : MonoBehaviour
{
    public ParticleSystem heart;
    public bool includeChildren = true;
    bool dragon = false, love = false;

    CharacterMovement characterMovementScript;

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        characterMovementScript = other.GetComponent<CharacterMovement>();
    //        characterMovementScript.paused = true;
    //        //StartSkillCheck
    //        StartCoroutine(WaitForEndofAction());
    //        if (love)
    //        {
    //            Debug.Log("LOVEACTIVITED");
    //            heart.Play(includeChildren);
    //        }

    //    }
    //}

    //IEnumerator WaitForEndofAction()
    //{
    //    yield return new WaitForSeconds(3.5f);
    //    characterMovementScript.paused = false;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        heart.Stop(includeChildren);
    //    }
    //}

}
