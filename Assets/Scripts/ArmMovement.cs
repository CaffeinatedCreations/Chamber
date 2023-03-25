using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ArmMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 joystickValue;
    private CharacterController controller;
    public PlayerController playerController; //got lazy grabbed varaible from other script
    private SpriteRenderer sr;
    public SpriteRenderer tar;
    
    


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = tar.color;
    }

    private void Update()
    {
        /* joystickValue = Gamepad.current.rightStick.ReadValue();

         float moveHorizontal = joystickValue.x;
         float moveVertical = joystickValue.y;

         Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

         transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        */
        
    }
    private void FixedUpdate()
    {
        if (playerController.rb.velocity.x < 0) //if rb from player controller flip flip arm
        {
            
            sr.flipX = true;
        }
        else if (playerController.rb.velocity.x > 0)
        {
            
            sr.flipX = false;
        }
    }
    public void MoveArm(InputAction.CallbackContext context)
    {
        //joystickValue = Gamepad.current.rightStick.ReadValue();

        float moveHorizontal = context.ReadValue<Vector2>().x;
        float moveVertical = context.ReadValue<Vector2>().y;

        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);

    }
}
