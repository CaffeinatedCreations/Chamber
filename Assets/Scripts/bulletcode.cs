using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcode : MonoBehaviour

{
    public string bulletEffect;
    public int userID;
    public Transform target;
    private float smoothFactor = 1f;


    // Start is called before the first frame update
    void Start()
    {
        if (userID == 0)
        {
            target = PlayerSpawnManager.instance.players[1].transform;
        }
        else
        {
            target = PlayerSpawnManager.instance.players[0].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletEffect == "Homing")
        {
            Vector3 desiredPos = new Vector3(target.transform.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothFactor * Time.deltaTime);
        }
    }


    public void setID(int desID)
    {
        Debug.Log("Set ID To: " + desID);
        userID = desID;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shield"))
        {
            // Refelect the bullet if it collides with a shield
            Vector3 newVelocity = Vector3.Reflect(transform.forward, collision.transform.forward);
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        // Check if the collision occurred with a player GameObject that is not the user GameObject
        else if (collision.CompareTag("Player") && collision.GetComponent<PlayerController>().playerID != userID)
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().Die();
        }else if(collision.CompareTag("bullet") && !(collision.GetComponent<bulletcode>().userID == userID))
            Destroy(gameObject);


        
        else if(!collision.CompareTag("Player") && !collision.CompareTag("bullet"))
            Destroy(gameObject);

    }
}