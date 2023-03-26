using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;         //The Rigidbody 2D attached to the Player //did make public for personal use
    private SpriteRenderer sr;      //The Sprite Renderer attached to the Player
    public GameObject eventSystem;

    public float inputX;           //States if the player is moving left or right
    public float moveSpeed;         //Determines how fast the player moves
    public float jumpForce;         //Determines how high the player jumps

    public bool isGrounded;         //States if the Player is on the ground or not
    public List<Transform> groundCheck;   //This must be touching ground for the player to jump
    public LayerMask whatIsGround;  //States what is considered ground

    public bool isControllable;

    public int playerID;
    public Vector2 spawnLocation;
    public string bulletEffect, weapon, defensive = "";



    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnLocation;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isControllable = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isControllable)
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck[0].position, 0.7f, whatIsGround); // Determines if the Player is on the Ground

        if(!isGrounded)
            isGrounded = Physics2D.OverlapCircle(groundCheck[1].position, 1f, whatIsGround);

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


    public void Die()
    {
        Debug.Log("Oops you died");
        PlayerSpawnManager.instance.setControllable(false);
        SkillSystem.instance.SetID(playerID);
        

        if (bulletEffect == "" && weapon == "" && defensive == "")
        {
            UIManager.instance.turnOnBackground();
            UIManager.instance.turnOnSkillSelector();
            UIManager.instance.turnOnBullet();
        }

        if (bulletEffect != "" && weapon == "" && defensive == "")
        {
            UIManager.instance.turnOnBackground();
            UIManager.instance.turnOnSkillSelector();
            UIManager.instance.turnOnDefense();
        }

        if (bulletEffect != "" && weapon == "" && defensive != "")
        {
            UIManager.instance.turnOnBackground();
            UIManager.instance.turnOnSkillSelector();
            UIManager.instance.turnOnGun();
        }



        this.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        PlayerSpawnManager.instance.RespawnPlayer(this.GetComponent<PlayerInput>());
        this.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");

    }


    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        
        if (isGrounded && context.performed && isControllable)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


}
