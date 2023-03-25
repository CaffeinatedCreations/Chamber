using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcode : MonoBehaviour

{
    public int userID;
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
        if (collision.CompareTag("Player") && !(collision.GetComponent<PlayerController>().playerID == userID))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().Die();
        }


        if(collision.CompareTag("bullet") && !(collision.GetComponent<bulletcode>().userID == userID))
            Destroy(gameObject);

        if (!collision.CompareTag("Player") && !collision.CompareTag("bullet"))
            Destroy(gameObject);

    }
}