using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private float moveX;
    [SerializeField]
    private float move = 5f, jump = 10f, dashForce = 15f;
    private bool grounded;
    private bool canDash;
    private float nextDash;

    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator anim;
    private SpriteRenderer sprite;

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
        Animate();
        Dash();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            grounded = true;
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
        if(Input.GetKey(KeyCode.LeftShift) && Time.time > nextDash)
        {
            Debug.Log("input");
            if(sprite.flipX == false) 
            {
                body.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
            else 
            {
                body.AddForce(new Vector2(-dashForce, 0), ForceMode2D.Impulse);
            }
            nextDash = Time.time + 1;
        }
    }
}