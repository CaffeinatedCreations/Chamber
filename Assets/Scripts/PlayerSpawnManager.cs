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

    private GameObject[] walls;
    public Camera mainCamera;

    private int wheretoSpawn1, wheretoSpawn2;



    private void Awake()
    {
        instance = this;
        walls = GameObject.FindGameObjectsWithTag("Wall");
        wheretoSpawn1 = 1;
        wheretoSpawn2 = 1;

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

        playerInput.GetComponent<PlayerController>().playerID = playerInput.playerIndex;
    }

    public void RespawnPlayer(PlayerInput playerID)
    {
        if (playerID.playerIndex == 0)
        {
            wheretoSpawn1--;
            wheretoSpawn2--;
            Debug.Log(wheretoSpawn1 + " "+ playerID.playerIndex);
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer1[wheretoSpawn1].position;
            DeactivateWallsLeft(walls);
        }

        if (playerID.playerIndex == 1)
        {
            wheretoSpawn1++;
            wheretoSpawn2++;
            Debug.Log(wheretoSpawn2 + " " + playerID.playerIndex);
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer2[wheretoSpawn2].position;
            DeactivateWallsRight(walls);
        }
    }


    public void DeactivateWallsRight(GameObject[] walls)
    {
        for (int i = 0; i <= walls.Length - 1; i++)
        {
            if (walls[i].transform.position.x > mainCamera.transform.position.x)
            {
                walls[i].SetActive(false);
            }
        }
    }

    public void DeactivateWallsLeft(GameObject[] walls)
    {
        for (int i = 0; i <= walls.Length; i++)
        {
            if (walls[i].transform.position.x < mainCamera.transform.position.x)
            {
                walls[i].SetActive(false);
            }
        }
    }

    public void ActivateWalls(GameObject[] walls)
    {
        for (int i = 0; i <= walls.Length; i++)
        {
            walls[i].SetActive(true);
        }
    }
}
