using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.XR;

public class DoorManagement : MonoBehaviour
{
    private bool PlayerOne, PlayerTwo;
    private bool ThatDoor;
    public GameObject obj, objTwo;
    public GameObject ParentObj, ParentObjTwo;

    private Animator anim, animTwo;

    private bool isOpen;
    public Spawning spawningScript;

    private List<bool> PlayersOnDoor = new List<bool>();

    void Start()
    {
        anim = obj.GetComponent<Animator>();
        animTwo = objTwo.GetComponent<Animator>();
    }

    // Update is called once per frame
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
            }
        }

        else if (isOpen)
            //DoorClosing();
            return;
    }

    public void DoorClosing()
    {
        anim.SetTrigger("Close");
        animTwo.SetTrigger("Close");
        isOpen = false;
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
