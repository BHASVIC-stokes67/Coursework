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

    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private GameObject bulletRef;
    private GameObject bullet;
    public float damage = 10;
    [SerializeField]
    private Transform location;
    private float attackSpeed, cooldown = 0.4f;

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
            body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            grounded = false;
        }
        else if (canDoubleJump > 0 && Input.GetButtonDown("Jump"))
        {
            body.linearVelocity = new Vector2(0, jump);
            canDoubleJump -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            grounded = true; 
            canDoubleJump = maxDoubleJump;
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

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
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
            cooldown = (float)(cooldown / 0.9);
        }
        else if (item == "gun_0(Clone)")
        {
            damage = (float)(damage * 1.1);
        }
    }
}