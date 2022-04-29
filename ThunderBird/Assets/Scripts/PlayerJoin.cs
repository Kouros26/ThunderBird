using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerJoin : MonoBehaviour
{ 
    int index = 0;
    [SerializeField] List<GameObject> characters = new List<GameObject>(); 
    PlayerInputManager manager;

    public Transform[] spawnLocations;
    public GameObject[] players = new GameObject[2];
    private int nbr = 0;

    void Start() 
    { 
        manager = GetComponent<PlayerInputManager>(); 
        index = manager.playerCount - 1; 
        manager.playerPrefab = characters[index]; 
    } 
    public void SwitchNextSpawnCharacters(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        //players[nbr] = playerInput.gameObject;
        //nbr++;

        index = manager.playerCount; 
        manager.playerPrefab = characters[index]; 
    } 
}