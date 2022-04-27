using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockpit : MonoBehaviour
{
    public Transform pilot;
    public Transform pilotView;
    public Transform coPilot;
    public Transform coPilotView;
    public CharacterMovement characterMovementScript;
    //public SkillCheck skillCheckScript;
    Transform player;

    Animator playerAnim;

    public bool checkForMove = false;

    private void Start()
    {
        //eventScript.CockpitMission();      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //skillCheckScript.SkillCheckStart();
            EventScript.isOccupied = true;
            player = other.GetComponent<Transform>();
            player.transform.position = pilot.transform.position;
            player.transform.LookAt(pilotView);
            playerAnim = other.GetComponent<Animator>();
            playerAnim.SetBool("Sit", true);
            characterMovementScript = other.GetComponent<CharacterMovement>();
            characterMovementScript.paused = true;
            EventScript.CockpitMission();
            StartCoroutine(WaitForMove());
        }
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(2);
        characterMovementScript.checkForMove = true;
    }
}
