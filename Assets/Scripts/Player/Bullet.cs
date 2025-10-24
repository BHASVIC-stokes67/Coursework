using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed, damage;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
        GameObject zombie = GameObject.Find("Zombie");
        GameObject gunner = GameObject.Find("Gunner");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        print(collisionLayer);
        if (collisionLayer == 10 || collisionLayer == 11)
        {
            print("collided with floor");
            Destroy(this.gameObject);
        }
        if (collisionLayer == 9)
        {
            if (collision.gameObject.CompareTag("Zombie"))
            {
                GameObject zombie = collision.gameObject;
                Enemy zombieScript = zombie.GetComponent<Enemy>();
                zombieScript.health -= damage;
            }
            else if (collision.gameObject.CompareTag("Gunner"))
            {
                GameObject gunner = collision.gameObject;
                Gunner gunnerScript = gunner.GetComponent<Gunner>();
                gunnerScript.health -= damage;
                print(gunnerScript.health);
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        if (collisionLayer == 10 || collisionLayer == 11)
        {
            print("collided with floor");
            Destroy(this.gameObject);
        }
    }
}
