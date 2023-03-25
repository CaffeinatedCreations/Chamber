using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public List<Transform> targets;
    public float moveAmount;
    public int smoothFactor, currentTarget;
    public bool shouldMoveLeft, shouldMoveRight;
    float step;


    private void Awake()
    {
        step = smoothFactor * Time.deltaTime;
        smoothFactor = 3;
        //moveAmount = 118.5f;
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMoveLeft)
        {
            Vector3 desiredPos = new Vector3(targets[currentTarget - 1].transform.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothFactor * Time.deltaTime);

            if (Vector3.Distance(transform.position, desiredPos) < 0.01f)
            {
                // Snap the camera to the desired position
                transform.position = desiredPos;
                currentTarget--;
                shouldMoveLeft = false;
            }
            

        }

        if (shouldMoveRight)
        {
            Vector3 desiredPos = new Vector3(targets[currentTarget + 1].transform.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothFactor * Time.deltaTime);

            if (Vector3.Distance(transform.position, desiredPos) < 0.01f)
            {
                // Snap the camera to the desired position
                transform.position = desiredPos;
                currentTarget++;
                shouldMoveRight = false;
                
            }

            
        }
    }

    public void moveLeft()
    {
        shouldMoveLeft = true;
    }

    public void moveRight()
    {
        shouldMoveRight = true;
    }
}
