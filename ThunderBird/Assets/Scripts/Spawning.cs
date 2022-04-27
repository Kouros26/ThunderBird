using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawning : MonoBehaviour
{
    public Transform[] spawnLocations;
    public static GameObject[] players = new GameObject[2];
    private int nbr = 0;

    public void OnPLayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        players[nbr] = playerInput.gameObject;
        nbr++;
    }
}
