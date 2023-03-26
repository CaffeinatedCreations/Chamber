using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Debug.Log("Calling move");
            if (collision.GetComponent<PlayerController>().playerID == 0)
            {
                CameraController.instance.moveRight();
                
            }

            if (collision.GetComponent<PlayerController>().playerID == 1)
            {
                CameraController.instance.moveLeft();
                
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;

            if (collision.GetComponent<PlayerController>().playerID == 0 && collision.GetComponent<SpriteRenderer>().flipX)
            {
                PlayerSpawnManager.instance.ForceRespawn(collision.GetComponent<PlayerInput>());
            }

            if (collision.GetComponent<PlayerController>().playerID == 1 && !collision.GetComponent<SpriteRenderer>().flipX)
            {
                PlayerSpawnManager.instance.ForceRespawn(collision.GetComponent<PlayerInput>());
            }
        }

        PlayerSpawnManager.instance.setControllable(true);
    }
}
