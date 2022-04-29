using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEngine : MonoBehaviour
{
    private bool PlayerOne, PlayerTwo;
    private bool OnEngine;
    public Spawning spawningScript;

    private List<bool> PlayersOnEngine = new List<bool>();

    public static bool CanResetEngine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resetEngine();
    }

    public void resetEngine()
    {
        PlayerOne = spawningScript.players[0].GetComponentInChildren<HandHitbox>().OnDoor;
        PlayerTwo = spawningScript.players[1].GetComponentInChildren<HandHitbox>().OnDoor;

        if (PlayerOne && PlayerTwo && OnEngine)
        {
            Debug.Log("Can Reset Engine");
            CanResetEngine = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayersOnEngine.Add(true);

            if (PlayersOnEngine[0] == true && PlayersOnEngine[1] == true)
                OnEngine = true;
            Debug.Log(PlayersOnEngine[0] + "," + PlayersOnEngine[1]);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayersOnEngine.RemoveAt(PlayersOnEngine.Count - 1);
            OnEngine = false;
            Debug.Log(PlayersOnEngine[0] + "," + PlayersOnEngine[1]);

        }
    }

}
