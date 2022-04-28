using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.XR;

public class DoorManagement : MonoBehaviour
{
    private bool PlayerOne, PlayerTwo;
    private bool ThatDoor;
    public GameObject obj, objTwo, doorUI;
    public GameObject LightOne, LightTwo, GroundOne, GroundTwo;
    public GameObject TWOLightOne, TWOLightTwo, TWOGroundOne, TWOGroundTwo;

    private Animator anim, animTwo;

    private bool isOpen;
    public Spawning spawningScript;
    static int doorCount;

    private List<bool> PlayersOnDoor = new List<bool>();

    void Start()
    {
        doorCount = 0;
        anim = obj.GetComponent<Animator>();
        animTwo = objTwo.GetComponent<Animator>();
    }

    void Update()
    {
        DoorOpening();
    }

    public void DoorOpening()
    {
        PlayerOne = spawningScript.players[0].GetComponentInChildren<HandHitbox>().OnDoor;
        PlayerTwo = spawningScript.players[1].GetComponentInChildren<HandHitbox>().OnDoor;

        if (PlayerOne && PlayerTwo && ThatDoor)
        {
            if (!isOpen)
            {
                anim.SetTrigger("Open");
                animTwo.SetTrigger("Open");
                isOpen = true;
                doorCount = doorCount + 1;

                doorUI.SetActive(false);
                LightOne.SetActive(false);
                LightTwo.SetActive(true);
                GroundOne.SetActive(false);
                GroundTwo.SetActive(true);

                TWOLightOne.SetActive(false);
                TWOLightTwo.SetActive(true);
                TWOGroundOne.SetActive(false);
                TWOGroundTwo.SetActive(true);
                if (doorCount == 3)
                {
                    EventManagerScript.allDoorsOpen = true;
                }
                if (doorCount >= 4)
                {
                    EventManagerScript.alreadyDoor = false;
                }
            }
        }
    }

    public void DoorClosing()
    {
        anim.SetTrigger("Close");
        animTwo.SetTrigger("Close");
        isOpen = false;

        doorUI.SetActive(true);
        LightTwo.SetActive(false);
        LightOne.SetActive(true);
        GroundTwo.SetActive(false);
        GroundOne.SetActive(true);

        TWOLightTwo.SetActive(false);
        TWOLightOne.SetActive(true);
        TWOGroundTwo.SetActive(false);
        TWOGroundOne.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayersOnDoor.Add(true);

            if (PlayersOnDoor[0] == true && PlayersOnDoor[1] == true)
                ThatDoor = true;
            Debug.Log(PlayersOnDoor[0] + "," + PlayersOnDoor[1]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayersOnDoor.RemoveAt(PlayersOnDoor.Count - 1);
            ThatDoor = false;

            Debug.Log(PlayersOnDoor[0] + "," + PlayersOnDoor[1]);
        }
    }
}
