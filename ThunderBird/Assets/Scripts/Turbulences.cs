using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbulences : MonoBehaviour
{
    public Transform coPilot;
    public Transform coPilotView;
    public static bool coPilotReady = false;
    CharacterMovement characterMovementScript;
    Transform player;

    Animator playerAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //skillCheckScript.SkillCheckStart();
            coPilotReady = true;
            player = other.GetComponent<Transform>();
            player.transform.position = coPilot.transform.position;
            player.transform.LookAt(coPilotView);
            playerAnim = other.GetComponent<Animator>();
            playerAnim.SetBool("Sit", true);
            characterMovementScript = other.GetComponent<CharacterMovement>();
            characterMovementScript.paused = true;
            EventScript.CockpitMission();
            StartCoroutine(WaitForEventEnd());
        }
    }

    IEnumerator WaitForEventEnd()
    {
        yield return new WaitForSeconds(2);
        characterMovementScript.checkForMove = true;
    }
}