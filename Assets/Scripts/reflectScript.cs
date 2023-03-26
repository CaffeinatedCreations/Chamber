using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectScript : MonoBehaviour
{

    private bool isShieldActive = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isShieldActive && collision.gameObject.CompareTag("bullet"))
        {
            Vector2 direction = Vector2.Reflect(collision.gameObject.GetComponent<Rigidbody2D>().velocity, collision.contacts[0].normal);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = direction;
        }
    }

    private IEnumerator ActivateShield()
    {
        isShieldActive = true;
        yield return new WaitForSeconds(1.5f);
        isShieldActive = false;
    }

    public void Activate()
    {
        StartCoroutine(ActivateShield());
    }
}

