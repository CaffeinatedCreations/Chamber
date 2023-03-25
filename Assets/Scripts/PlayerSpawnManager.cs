using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{

    public List<Sprite> player1Sprites;
    public List<Sprite> player2Sprites;

    public List<Transform> spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        if (playerInput.playerIndex == 0)
            playerInput.gameObject.GetComponent<SpriteRenderer>().color = Color.green;


        if (playerInput.playerIndex == 1)
            playerInput.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerDetails>().spawnLocation = spawnLocations[playerInput.playerIndex].position;
    }
}
