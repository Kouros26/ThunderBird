using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaressTheDragon : MonoBehaviour
{
    [SerializeField] private ParticleSystem heart;
    public CharacterMovement characterMovementScript;
    public EventManagerScript eventManagerScript;
    Animator animDebug;
    //bool dragon = false;
    public bool love = false;

 //   CharacterMovement characterMovementScript;

    void Start()
    {
        heart = GameObject.Find("Heart").GetComponent<ParticleSystem>();
        heart.Clear();
        //heart.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            characterMovementScript = other.GetComponent<CharacterMovement>();
            animDebug = other.GetComponent<Animator>();
        }
    }
    void FixedUpdate()

    {
        if (love && !heart.isEmitting)
        {
            animDebug.SetBool("Move", false);
            characterMovementScript.paused = true;
            heart.Play();
            StartCoroutine(DragonInteraction());
        }
    }

    IEnumerator DragonInteraction()
    {
        yield return new WaitForSeconds(5);
        characterMovementScript.paused = false;
        eventManagerScript.DragonFinished();
        heart.Stop();
        love = false;
    }


    //IEnumerator WaitForEndofAction()
    //{
    //    yield return new WaitForSeconds(3.5f);
    //    characterMovementScript.paused = false;
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            characterMovementScript = null;
        }
    }
}
