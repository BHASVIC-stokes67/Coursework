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
        if (collision.gameObject.CompareTag("Wall") || collisionLayer == 8 || collision.gameObject.CompareTag("floor"))
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
                Enemy gunnerScript = gunner.GetComponent<Enemy>();
                gunnerScript.health -= damage;
            }
            Destroy(this.gameObject);
        }
    }
}
