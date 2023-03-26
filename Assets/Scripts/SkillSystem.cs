using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;
    public int playerID;
    public List<TMP_Text> skillName;
    public List<TMP_Text> skillDescription;
    public List<Image> Icon;
    private string bulletEffect, weapon, defense;
    public List<CreateSkill> upgradesBullet, upgradesWeapon, upgradesDefense;
    //public List<Button> button;
    public GameObject thisObject;

    private void Awake()
    {
        instance = this;
        bulletEffect = PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect;
        weapon = PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon;
        defense = PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive;
    }




    public void giveShotgun()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Shotgun";
        thisObject.SetActive(false);
    }

    public void giveUzi()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Uzi";
        thisObject.SetActive(false);
    }

    public void giveSword()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().weapon = "Sword";
        thisObject.SetActive(false);
    }

    public void giveHoming()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Homing";
        thisObject.SetActive(false);
    }

    public void giveExplode()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Explode";
        thisObject.SetActive(false);
    }

    public void giveRicochet()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().bulletEffect = "Ricochet";
        thisObject.SetActive(false);
    }

    public void giveBlock()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Block";
        thisObject.SetActive(false);
    }

    public void giveDeflect()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Deflect";
        thisObject.SetActive(false);
    }

    public void giveJam()
    {
        PlayerSpawnManager.instance.players[playerID].GetComponent<PlayerController>().defensive = "Jam";
        thisObject.SetActive(false);
    }

}
