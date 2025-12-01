using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;

public class PlayerScript : MonoBehaviour
{
    private float moveX;
    [SerializeField]
    private float move = 5f, jump = 10f, dashForce = 10f;
    public float health = 25;
    private bool grounded;
    private int canDoubleJump, maxDoubleJump = 1;
    private float nextDash;
    [SerializeField]
    public float money = 100;

    
    [SerializeField]
    private LayerMask Layer;

    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private GameObject bulletRef;
    private GameObject bullet;
    public float damage = 5;
    [SerializeField]
    private Transform location;
    private float attackSpeed, cooldown = 0.4f;

    //Getting all of the components
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Dash();
        Animate();
        Attack();
        Die();
    }

    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0, 0) * move * Time.deltaTime;
    }

    private void Jump()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jump);
            grounded = false;
        }
        else if (canDoubleJump > 0 && Input.GetButtonDown("Jump"))
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jump);
            canDoubleJump -= 1;
        }
    }

    //Double-Jump code. It detects when you hit the floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.1f, Layer))
        {
            grounded = true;
            canDoubleJump = maxDoubleJump;
        }
        if(collision.gameObject.CompareTag("Down"))
        {
            transform.position = new Vector2(transform.position.x, 0);
            body.linearVelocity = new Vector2(body.linearVelocityX, 0);
        }
    }

    private void Animate()
    {
        if(anim.GetBool("isHolding") == false) 
        {
            if(moveX > 0)
            {
                anim.SetBool("isRunning", true);
                sprite.flipX = false;
            }
            else if (moveX < 0)
            {
                anim.SetBool("isRunning", true);
                sprite.flipX = true;
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
        else{
            if(moveX > 0)
            {
                anim.SetBool("isRunning", true);
                sprite.flipX = false;
            }
            else if (moveX < 0)
            {
                anim.SetBool("isRunning", true);
                sprite.flipX = true;
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
    }

    //Dashing adds force instead of setting a direction and fixed horizontal speed
    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Time.time > nextDash)
        {
            if (sprite.flipX == false)
            {
                body.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
            else 
            { 
                body.AddForce(new Vector2(-dashForce, 0), ForceMode2D.Impulse); 
            }
            nextDash = Time.time + 0.5f;
        }
    }

    //Creates a bullet when you are holding the gun on input
    private void Attack() {
        if(Input.GetMouseButtonDown(0) && Time.time > attackSpeed && anim.GetBool("isHolding")) {
            bullet = Instantiate(bulletRef);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
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
            attackSpeed = Time.time + 0.4f;
        }
    }

    //Kills you
    private void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    //This does not actually add anything to an inventry, it adds the bonus from the item to the player instead
    public void addToInventory(String item)
    {
        if(item == "Weapon_0") 
        {
            anim.SetBool("isHolding", true);
        }
        else if (item == "Ace_0(Clone)")
        {
            move += 5;
        }
        else if(item == "Monter_0(Clone)")
        {
            maxDoubleJump += 1;
            canDoubleJump += 1;
        }
        else if (item == "Broken_Sword_0(Clone)")
        {
            cooldown = (float)(cooldown / 0.6);
        }
        else if (item == "gun_0(Clone)")
        {
            damage = (float)(damage * 1.3);
        }
    }
}