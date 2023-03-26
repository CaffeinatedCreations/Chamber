using JetBrains.Annotations;
using System;
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
    public GameObject bulletref;

    

    public Sprite shoot;
    public Sprite noShoot;
    public bool canSpawnBullet = true;
    public float bulletSpawnCooldown = 1f; // adjust the cooldown duration as needed
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint2;
    public Transform gunTransform;

    private AudioSource shootingAudio;
    private int bulletstate = 1;
    public int weaponstate = 3;
    private int defensestate = 0;


    public GameObject player;
    public GameObject playerPrefab;

    public float bulletForce;
    public int armID = -1;
    private int offset;
    private Rigidbody rb;

    public string weapon;


    public GameObject laserprefab;

    public soundManagerScript soundManager;

    public void Start()
    {
        offset = 2;
        
        sr = GetComponent<SpriteRenderer>();
        sr.color = tar.color;
        shootingAudio = GetComponent<AudioSource>();
        armID = GetComponentInParent<PlayerController>().playerID;
        bulletForce = 12f;



    }

    private void Update()
    {
        weapon = GetComponentInParent<PlayerController>().weapon;

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
        if (sr.flipX)
            offset = 178;

        if (!sr.flipX)
            offset = 2;
    }
    public void MoveArm(InputAction.CallbackContext context) //idk why its 90 degrees off //Try looking at this https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
    {


        float moveHorizontal = context.ReadValue<Vector2>().x;
        float moveVertical = context.ReadValue<Vector2>().y;
        
        //Debug.Log("Horizontal: " + moveHorizontal);
        //Debug.Log("Vertical: " + moveVertical);



        float angle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        // Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);

    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shield(defensestate);
        }
    }

    public void shield(int a)
    {

        if(a == 1)
        {
            player.tag = "Invincible";
        }else if(a == 2)
        {
            //bubble
            void OnCollisionEnter2D(Collision2D collision)
            {
                rb = GetComponent<Rigidbody>();

                // Get the normal of the collision to reflect the bullet's velocity
                Vector2 normal = collision.contacts[0].normal;
                Vector2 newVelocity = Vector2.Reflect(rb.velocity, normal);

                // Set the new velocity to the bullet
                rb.velocity = newVelocity;
                
            }
        }
        else if(a ==3)
        {
            //disarms gun to stop
        }
    }

    public void shootanimation(InputAction.CallbackContext context) //changes when trigger is pressed
    {
        try
        {
            //soundManager.PlaySound("happytime");
            //sr.sprite = shoot;
            //Debug.Log("Shoot");
            if (context.performed && canSpawnBullet)
            { 
                changeweapon(weapon);
                Debug.Log("Changed weapon to: " + weapon);
            }
        }catch(Exception e)   
        {
            Debug.Log(e.ToString());
        }


    }
    private IEnumerator ResetSpriteAfterDelay(float delay) //returns to default 
    {
        yield return new WaitForSeconds(delay);
        sr.sprite = noShoot;
    }

    private IEnumerator StartBulletSpawnCooldown(float num)
    {
        // Wait for specified duration
        yield return new WaitForSeconds(num);

        // Enable ability to spawn bullet again
        canSpawnBullet = true;
        sr.sprite = noShoot;
    }
    private IEnumerator nowait(float num)
    {
        yield return new WaitForSeconds(num);
        // Enable ability to spawn bullet again
        canSpawnBullet = true;
        sr.sprite = noShoot;
    }
    private IEnumerator lasershot(float num)
    {
        Debug.Log("Lasershot started");
        yield return new WaitForSeconds(num);

        if (sr.flipX)
        {
           
            Debug.Log("ls deactivated");
        }

        if (!sr.flipX)
        {
           
            Debug.Log("ls2 deactivated");

        }
    }

    public void changeweapon(string weapon)
    {
        if (weapon == "")
        {
            
            shootingAudio.PlayOneShot(shootingAudio.clip);
            //sr.sprite = shoot;
            Debug.Log("Shoot");
            // Calculate the bullet spawn position based on the bulletSpawnPoint's position and orientation
            Vector3 bulletSpawnPosition = bulletSpawnPoint.position;
            Quaternion bulletSpawnRotation = bulletSpawnPoint.rotation;
            if (sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint2.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            if (!sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            // Spawn bullet at the calculated position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);

            bullet.GetComponent<bulletcode>().setID(armID);


            Vector3 shootDirection = transform.right;

            if (sr.flipX)
                shootDirection = -transform.right;

            if (!sr.flipX)
                shootDirection = transform.right;

            
            // Add force to the bullet in the shoot direction
            bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

            canSpawnBullet = false;
            StartCoroutine(StartBulletSpawnCooldown(1f));

        }
        else if (weapon == "Uzi") //uzi
        {
            shootingAudio.PlayOneShot(shootingAudio.clip);
            //sr.sprite = shoot;
            Debug.Log("Shoot");

            // Calculate the bullet spawn position based on the bulletSpawnPoint's position and orientation
            Vector3 bulletSpawnPosition = bulletSpawnPoint.position;
            Quaternion bulletSpawnRotation = bulletSpawnPoint.rotation;
            if (sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint2.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            if (!sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            // Spawn bullet at the calculated position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);

            bullet.GetComponent<bulletcode>().setID(armID);

            Vector3 shootDirection = transform.right;

            if (sr.flipX)
                shootDirection = -transform.right;

            if (!sr.flipX)
                shootDirection = transform.right;

            // Add force to the bullet in the shoot direction
            bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * 12f, ForceMode2D.Impulse);


            canSpawnBullet = false;
            StartCoroutine(nowait(0f));
        }
        else if (weapon == "Shotgun") //shotgun
        {
            shootingAudio.PlayOneShot(shootingAudio.clip);
            Debug.Log("Shoot");

            // Calculate the bullet spawn position based on the bulletSpawnPoint's position and orientation
            Vector3 bulletSpawnPosition = bulletSpawnPoint.position;
            Quaternion bulletSpawnRotation = bulletSpawnPoint.rotation;
            if (sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint2.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            if (!sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            // Spawn bullet at the calculated position and rotation
            GameObject bullet1 = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);
            GameObject bullet2 = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);
            GameObject bullet3 = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);

            bullet1.GetComponent<bulletcode>().setID(armID);
            bullet2.GetComponent<bulletcode>().setID(armID);
            bullet3.GetComponent<bulletcode>().setID(armID);

            // Calculate the shoot directions
            Vector3 shootDirection1 = Quaternion.Euler(0, 0, 20) * transform.right;
            Vector3 shootDirection2 = transform.right;
            Vector3 shootDirection3 = Quaternion.Euler(0, 0, -20) * transform.right;

            if (sr.flipX)
            {
                shootDirection1 = -shootDirection1;
                shootDirection2 = -shootDirection2;
                shootDirection3 = -shootDirection3;
            }

            // Add force to the bullets in the shoot directions
            bullet1.GetComponent<Rigidbody2D>().AddForce(shootDirection1 * 12f, ForceMode2D.Impulse);
            bullet2.GetComponent<Rigidbody2D>().AddForce(shootDirection2 * 12f, ForceMode2D.Impulse);
            bullet3.GetComponent<Rigidbody2D>().AddForce(shootDirection3 * 12f, ForceMode2D.Impulse);

            canSpawnBullet = false;
            StartCoroutine(nowait(1f));
        }
        

        else if(weapon == "Sword")

        {
            shootingAudio.PlayOneShot(shootingAudio.clip);
            //sr.sprite = shoot;
            Debug.Log("Shoot");
            // Calculate the bullet spawn position based on the bulletSpawnPoint's position and orientation
            Vector3 bulletSpawnPosition = bulletSpawnPoint.position;
            Quaternion bulletSpawnRotation = bulletSpawnPoint.rotation;
            if (sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint2.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            if (!sr.flipX)
                bulletSpawnPosition = bulletSpawnPoint.position;
            bulletSpawnRotation = bulletSpawnPoint.rotation;

            // Spawn bullet at the calculated position and rotation
            GameObject bullet = Instantiate(laserprefab, bulletSpawnPosition, bulletSpawnRotation);

            Vector3 shootDirection = transform.right;

            if (sr.flipX)
                shootDirection = -transform.right;

            if (!sr.flipX)
                shootDirection = transform.right;

            bullet.GetComponent<bulletcode>().userID = armID;
            // Add force to the bullet in the shoot direction
            bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

            canSpawnBullet = false;
            StartCoroutine(StartBulletSpawnCooldown(1f));
        }
    }
}
