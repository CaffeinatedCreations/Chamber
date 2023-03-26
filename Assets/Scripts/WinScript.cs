using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerSpawnManager.instance.setControllable(false);
            UIManager.instance.turnOnBackground();

            if (collision.GetComponent<PlayerController>().playerID == 0)
            {
                UIManager.instance.winScreenOnGreen();
            }

            if (collision.GetComponent<PlayerController>().playerID == 1)
            {
                UIManager.instance.winScreenOnBlue();
            }
        }
    }
}
