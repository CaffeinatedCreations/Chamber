using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ArmMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 joystickValue;

    private void Update()
    {
        joystickValue = Gamepad.current.rightStick.ReadValue();

        float moveHorizontal = joystickValue.x;
        float moveVertical = joystickValue.y;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
    }
}
