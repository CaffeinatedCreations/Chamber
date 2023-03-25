using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;

    public List<Sprite> player1Sprites;
    public List<Sprite> player2Sprites;

    public List<Transform> spawnLocationsPlayer1;
    public List<Transform> spawnLocationsPlayer2;

    private int wheretoSpawn1, wheretoSpawn2 = 1;



    private void Awake()
    {
        instance = this;
    }

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
        {
            playerInput.GetComponent<SpriteRenderer>().color = Color.green;
            playerInput.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer1[1].position;
        }


        if (playerInput.playerIndex == 1)
        {
            playerInput.GetComponent<SpriteRenderer>().color = Color.blue;
            playerInput.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer2[1].position;
        }

        playerInput.gameObject.GetComponent<PlayerController>().playerID = playerInput.playerIndex;
    }

    public void RespawnPlayer(PlayerInput playerID)
    {
        if (playerID.playerIndex == 0)
        {
            wheretoSpawn1--;
            wheretoSpawn2--;
            Debug.Log(wheretoSpawn1 + " "+ playerID.playerIndex);
            playerID.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer1[wheretoSpawn1].position;
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer1[wheretoSpawn1].position;
        }

        if (playerID.playerIndex == 1)
        {
            wheretoSpawn1++;
            wheretoSpawn2++;
            Debug.Log(wheretoSpawn2 + " " + playerID.playerIndex);
            playerID.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer2[wheretoSpawn2].position;
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer2[wheretoSpawn2].position;
        }
    }
}
