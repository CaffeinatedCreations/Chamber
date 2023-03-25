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
    private int weaponstate = 1;
    private int defensestate = 1;


    public GameObject player;

    public float bulletForce;
    public int armID;
    private int offset;

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
    

    public void shootanimation(InputAction.CallbackContext context) //changes when trigger is pressed
    {

        try
        {
            //sr.sprite = shoot;
            Debug.Log("Shoot");
            if (context.performed && canSpawnBullet)
            {
                /*
                changeweapon(2);
                //sr.sprite = shoot;
                Debug.Log("Shoot");
                shootingAudio.PlayOneShot(shootingAudio.clip);

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


                Vector3 shootDirection = transform.right;

                if (sr.flipX)
                    shootDirection = -transform.right;

                //if (!sr.flipX)
                //shootDirection = transform.right;

                bullet.GetComponent<bulletcode>().userID = armID;
                // Add force to the bullet in the shoot direction
                bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
                

                canSpawnBullet = false;
                StartCoroutine(StartBulletSpawnCooldown(bulletSpawnCooldown));
                */
                changeweapon(weaponstate);
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

    public void changeweapon(int num)
    {
        if (num == 1)
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
        else if (num == 2)
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


            Vector3 shootDirection = transform.right;

            if (sr.flipX)
                shootDirection = -transform.right;

            if (!sr.flipX)
                shootDirection = transform.right;

            // Add force to the bullet in the shoot direction
            bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * 12f, ForceMode2D.Impulse);

            canSpawnBullet = false;
            StartCoroutine(StartBulletSpawnCooldown(.25f));
        }
        else if (num == 3)
        {

        }else if(num == 4)
        {

        }
    }
}
