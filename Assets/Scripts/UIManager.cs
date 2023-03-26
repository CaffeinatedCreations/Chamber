using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int currentPlayerIndex = 0;

    [SerializeField]
    private GameObject blackBackground, SkillSelectScreen, GunHolder, BulletHolder, DefenseHolder, WinScreenBlue, WinScreenGreen;

    [SerializeField]
    private GameObject gunButton, bulletButton, defenseButton;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void winScreenOnBlue()
    {
        WinScreenBlue.SetActive(true);
    }

    public void winScreenOnGreen()
    {
        WinScreenGreen.SetActive(true);
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
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(gunButton, new BaseEventData(eventSystem));
    }

    public void turnOnBullet()
    {
        BulletHolder.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(bulletButton, new BaseEventData(eventSystem));
    }

    public void turnOnDefense()
    {
        DefenseHolder.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(defenseButton, new BaseEventData(eventSystem));
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
