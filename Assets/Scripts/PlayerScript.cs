using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    private float moveX;
    [SerializeField]
    private float move = 5f, jump = 10f, dashForce = 10f;
    private bool grounded;
    private int canDoubleJump, maxDoubleJump = 1;
    private float nextDash;

    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private GameObject Bullet;

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

    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Time.time > nextDash)
        {
            if (sprite.flipX == false) body.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            else body.AddForce(new Vector2(-dashForce, 0), ForceMode2D.Impulse);
            nextDash = Time.time + 0.5f;
        }
    }

    private void attack() {
        if(Input.GetMouseButtonDown(0)) {

        }
    }
    
    public void addToInventory(String item)
    {
        if (item == "Ace_0(Clone)")
        {
            move += 5;
        }
        else if(item == "Monter_0(Clone)")
        {
            maxDoubleJump += 1;
            canDoubleJump += 1;
        }
    }
}