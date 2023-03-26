using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;

    public List<Sprite> player1Sprites;
    public List<Sprite> player2Sprites;

    public List<Transform> spawnLocationsPlayer1;
    public List<Transform> spawnLocationsPlayer2;

    [SerializeField]
    public PlayerInput[] players;

    private GameObject[] walls;
    public Camera mainCamera;

    public int numDeadCharacters = 0;

    private int wheretoSpawn1, wheretoSpawn2;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        players = new PlayerInput[2];
        walls = GameObject.FindGameObjectsWithTag("Wall");
        wheretoSpawn1 = 3;
        wheretoSpawn2 = 3;

    }


    public void onPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        if (playerInput.playerIndex == 0)
        {
            playerInput.GetComponent<SpriteRenderer>().color = Color.green;
            playerInput.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer1[3].position;
            playerInput.GetComponent<PlayerController>().playerID = playerInput.playerIndex;
            players[0] = playerInput;
        }


        if (playerInput.playerIndex == 1)
        {
            playerInput.GetComponent<SpriteRenderer>().color = Color.blue;
            playerInput.GetComponent<PlayerController>().spawnLocation = spawnLocationsPlayer2[3].position;
            playerInput.GetComponent<PlayerController>().playerID = playerInput.playerIndex;
            players[1] = playerInput;
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
            try
            {
                playerID.GetComponent<Transform>().position = spawnLocationsPlayer1[wheretoSpawn1].position;
            }
            catch (Exception e)
            {
                playerID.gameObject.SetActive(false);
            }


            DeactivateWallsLeft(walls);
        }

        if (playerID.playerIndex == 1)
        {
            wheretoSpawn1++;
            wheretoSpawn2++;
            Debug.Log(wheretoSpawn2 + " " + playerID.playerIndex);
            try
            {
                playerID.GetComponent<Transform>().position = spawnLocationsPlayer2[wheretoSpawn2].position;
            }catch(Exception e)
            {
                playerID.gameObject.SetActive(false);
            }
            DeactivateWallsRight(walls);
        }
    }


    public void ForceRespawn(PlayerInput playerID)
    {
        if (playerID.playerIndex == 0)
        {
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer1[wheretoSpawn1].position;
        }

        if (playerID.playerIndex == 1)
        {
            playerID.GetComponent<Transform>().position = spawnLocationsPlayer2[wheretoSpawn2].position;
        }
    }


    public void DeactivateWallsRight(GameObject[] walls)
    {
        for (int i = 0; i <= walls.Length - 1; i++)
        {
            if (walls[i].transform.position.x > mainCamera.transform.position.x)
            {
                walls[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    public void DeactivateWallsLeft(GameObject[] walls)
    {
        for (int i = 0; i <= walls.Length - 1; i++)
        {
            if (walls[i].transform.position.x < mainCamera.transform.position.x)
            {
                walls[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    public void activate()
    {
        ActivateWalls(walls);
    }

    public void ActivateWalls(GameObject[] walls) {
        for (int i = 0; i <= walls.Length - 1; i++)
        {
            walls[i].GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    public void setControllable(bool controllable)
    {
        players[0].GetComponent<PlayerController>().isControllable = controllable;
        players[0].GetComponent<PlayerController>().rb.velocity = Vector2.zero;

        players[1].GetComponent<PlayerController>().isControllable = controllable;
        players[1].GetComponent<PlayerController>().rb.velocity = Vector2.zero;
    }
}
