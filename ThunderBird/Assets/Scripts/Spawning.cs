using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawning : MonoBehaviour
{
    [Header("Kouros' Script")]
    public Transform[] spawnLocations;
    public GameObject[] players = new GameObject[2];
    private int nbr = 0;

    [Header("Gifted Script")]
    int index = 0;
    [SerializeField] List<GameObject> characters = new List<GameObject>();
    PlayerInputManager manager;

    void Start() //Start function is gifted
    {
        manager = GetComponent<PlayerInputManager>();
        index = manager.playerCount - 1;
        manager.playerPrefab = characters[index];
    }

    public void OnPLayerJoined(PlayerInput playerInput)
    {
        //kouros
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        players[nbr] = playerInput.gameObject;
        nbr++;

        //gifted
        index = manager.playerCount;
        manager.playerPrefab = characters[index];
    }
}
