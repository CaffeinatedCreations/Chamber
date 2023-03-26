using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int currentPlayerIndex = 0;

    [SerializeField]
    private GameObject blackBackground, SkillSelectScreen, GunHolder, BulletHolder, DefenseHolder;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void turnOnBackground()
    {
        blackBackground.SetActive(true);
    }

    public void turnOnSkillSelector()
    {
        SkillSelectScreen.SetActive(true);
    }

    public void turnOnGun()
    {
        GunHolder.SetActive(true);
    }

    public void turnOnBullet()
    {
        BulletHolder.SetActive(true);
    }

    public void turnOnDefense()
    {
        DefenseHolder.SetActive(true);
    }

    public void turnOffAll()
    {
        blackBackground.SetActive(false);
        SkillSelectScreen.SetActive(false);
        GunHolder.SetActive(false);
        BulletHolder.SetActive(false);
        DefenseHolder.SetActive(false);
    }
}
