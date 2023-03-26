using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;
    public int playerID = -1;
    public GameObject thisObject;

    private void Awake()
    {
        instance = this;
    }


    public void SetID(int desID)
    {
        Debug.Log("Setting ID");
        playerID = desID;
    }

    public void giveShotgun()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Shotgun";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveUzi()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Uzi";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveSword()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Sword";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveHoming()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Homing";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveExplode()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Explode";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveRicochet()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Ricochet";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveBlock()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Block";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

    public void giveDeflect()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Deflect";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        // thisObject.SetActive(false);
    }

    public void giveJam()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Jam";
        PlayerSpawnManager.instance.setControllable(true);
        UIManager.instance.turnOffAll();
        //thisObject.SetActive(false);
    }

}
