using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ArmMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 joystickValue;

    private void Update()
    {
       /* joystickValue = Gamepad.current.rightStick.ReadValue();

        float moveHorizontal = joystickValue.x;
        float moveVertical = joystickValue.y;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
       */
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
