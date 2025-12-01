using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    // Player references
    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private Transform playerTransform;
    private Vector3 playerLocation;
    [SerializeField]
    private PlayerScript playerScript;
    private LayerMask layer;

    // Attack references
    [SerializeField]
    private GameObject bulletRef;
    private GameObject bullet;
    [SerializeField]
    private GameObject rocksRef;
    private GameObject rocks;

    // Self-references + variables
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Transform location;
    [SerializeField]
    private CapsuleCollider2D meleeRange;
    private int damage = 5;
    private float health = 50;
    private float attackCooldown = 0;
    private bool canAttack = true;

private void Start()
    {
         StartCoroutine(cooldown());
    }
    private void Update()
    {
        Vector3 playerLocation = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
        if (playerLocation.x > location.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
        // if(canAttack)
        // {
        //     Attack();
        //     canAttack = false;
        // }
        // else
        // {
        //     StartCoroutine(cooldown());
        // }
    }

    private void Attack()
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
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3f);
        Attack();
        StartCoroutine(cooldown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        layer = collision.gameObject.layer;
        if (layer == 6)
        {
            anim.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        layer = collision.gameObject.layer;
        if (layer == 6)
        {
            playerScript.health -= damage;
            if (playerLocation.x > location.position.x && Time.time > attackCooldown)
            {
                player.AddForce(new Vector2(100, 10), ForceMode2D.Impulse);
                playerScript.health -= damage;
                attackCooldown = Time.time + 0.5f;
            }
            else if (playerLocation.x < location.position.x && Time.time > attackCooldown)
            {
                player.AddForce(new Vector2(-100, 10), ForceMode2D.Impulse);
                playerScript.health -= damage;
                attackCooldown = Time.time + 0.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        layer = collision.gameObject.layer;
        if (layer == 6)
        {
            anim.SetBool("isAttacking", false);
        }
    }
}
