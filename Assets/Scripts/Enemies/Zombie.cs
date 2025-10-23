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
        if (collision.gameObject.CompareTag("Player"))
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
        if (collision.gameObject.CompareTag("Wall"))
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("IsAttacking", false);
    }
}
