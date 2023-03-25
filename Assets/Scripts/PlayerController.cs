using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;         //The Rigidbody 2D attached to the Player
    private SpriteRenderer sr;      //The Sprite Renderer attached to the Player

    public float inputX;           //States if the player is moving left or right
    public float moveSpeed;         //Determines how fast the player moves
    public float jumpForce;         //Determines how high the player jumps

    public bool isGrounded;         //States if the Player is on the ground or not
    public Transform groundCheck;   //This must be touching ground for the player to jump
    public LayerMask whatIsGround;  //States what is considered ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround); // Determines if the Player is on the Ground

        //Flips the way the Player Sprite is facing
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }


    }


    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
