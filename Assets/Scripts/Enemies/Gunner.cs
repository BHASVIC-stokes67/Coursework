using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Gunner : Enemy
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private GameObject bulletRef;
    private GameObject bullet;
    [SerializeField]
    private Transform location;
    private float attackSpeed;

    void Update()
    {
        Shoot();
        die();
    }

    private void Shoot()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerLocation = player.GetComponent<Transform>();
        if (playerLocation.transform.position.x < location.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (Time.time > attackSpeed)
        {
            bullet = Instantiate(bulletRef);
            e_bullet bulletScript = bullet.GetComponent<e_bullet>();
            if (sprite.flipX == false)
            {
                bullet.transform.position = location.position + new Vector3(1, 0, 0);
                bulletScript.damage = damage;
                bulletScript.speed = 20;
            }
            else
            {
                bullet.transform.position = location.position + new Vector3(-1, 0, 0);
                bulletScript.damage = damage;
                bulletScript.speed = -20;
            }
            attackSpeed = Time.time + 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        if(collisionLayer == 13)
        {
            if (sprite.flipX)
            {
                sprite.flipX = false;
                body.AddForce(new Vector2(-5, 15), ForceMode2D.Impulse);
                health -= 2;
            }
            else
            {
                sprite.flipX = true;
                body.AddForce(new Vector2(5, 15), ForceMode2D.Impulse);
                health -= 2;
            }
        }
    }
}
