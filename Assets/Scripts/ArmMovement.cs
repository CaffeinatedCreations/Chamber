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

    public Sprite shoot;
    public Sprite noShoot;

    public GameObject player;
    float moveHorizontal;
    float moveVertical;

    private int offset;

    public void Start()
    {
        offset = 2;
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
    public void MoveArm(InputAction.CallbackContext context) //idk why its 90 degrees off //Try looking at this https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
    {

        if (sr.flipX)
            offset = 178;

        if (!sr.flipX)
            offset = 2;

        float moveHorizontal = context.ReadValue<Vector2>().x;
        float moveVertical = context.ReadValue<Vector2>().y;
        
        Debug.Log("Horizontal: " + moveHorizontal);
        Debug.Log("Vertical: " + moveVertical);



        float angle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        // Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);

    }
    

    public void shootanimation(InputAction.CallbackContext context) //changes when trigger is pressed
    {
        sr.sprite = shoot;
        Debug.Log("Shoot");
        StartCoroutine(ResetSpriteAfterDelay(.5f));
    }
    private IEnumerator ResetSpriteAfterDelay(float delay) //returns to default 
    {
        yield return new WaitForSeconds(delay);
        sr.sprite = noShoot;
    }
}
