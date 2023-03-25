using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcode : MonoBehaviour

{

    public PlayerController shooter;

    public GameObject user;
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
        // Check if the collision occurred with a player GameObject that is not the user GameObject
        if (collision.CompareTag("Player") && collision.gameObject != user)
        {
            collision.GetComponent<PlayerController>().Die();
        }

        // Check if the collision occurred with something other than the user GameObject
        if (collision.gameObject != user)
        {
            // Destroy the bullet GameObject
            Destroy(gameObject);
        }
    }
}