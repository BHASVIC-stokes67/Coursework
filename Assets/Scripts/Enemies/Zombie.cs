using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField]
    Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
        int collisionLayer = collision.gameObject.layer;
        if (collisionLayer == 6)
        {
            animator.SetBool("IsAttacking", true);
            if (sprite.flipX == false)
            {
                body.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
                playerBody.AddForce(new Vector2(13, 0), ForceMode2D.Impulse);
            }
            else
            {
                body.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
                playerBody.AddForce(new Vector2(-13, 0), ForceMode2D.Impulse);
            }
            script.health -= damage;
        }
        else if (collisionLayer == 10 || collisionLayer == 11)
        {
            if (sprite.flipX)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        else if(collisionLayer == 13)
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("IsAttacking", false);
    }
}
