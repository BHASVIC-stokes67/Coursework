using UnityEngine;
using UnityEngine.Rendering;

public class Spikes : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        SpriteRenderer SR = player.GetComponent<SpriteRenderer>();
        int collisionLayer = collision.gameObject.layer;
        if(collisionLayer == 6)
        {
            if (SR.flipX == false)
            {
                body.AddForce(new Vector2(-5, 15), ForceMode2D.Impulse);
                script.health -= 3;
            }
            else
            {
                body.AddForce(new Vector2(5, 15), ForceMode2D.Impulse);
                script.health -= 3;
            }
        }
    }
}
