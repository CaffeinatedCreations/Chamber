using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int currentPlayerIndex = 0;

    [SerializeField]
    private GameObject blackBackground, SkillSelectScreen;


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
}
