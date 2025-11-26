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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        if (collisionLayer == 10 || collisionLayer == 11)
        {
            Destroy(this.gameObject);
        }
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
        }
        Destroy(this.gameObject);
    }
}
