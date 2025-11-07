using UnityEngine;

public class e_bullet : MonoBehaviour
{
    public float speed, damage;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        if (collisionLayer == 6 || collisionLayer == 10 || collisionLayer == 11)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerScript.health -= damage;
                if (speed > 0)
                {
                    body.AddForce(new Vector2(15, 5), ForceMode2D.Impulse);
                }
                else
                {
                    body.AddForce(new Vector2(-15, 5), ForceMode2D.Impulse);
                }
                body.AddForce(new Vector2(-5, 15), ForceMode2D.Impulse);
                print("collided with player");
                Destroy(this.gameObject);
            }
            if(collisionLayer == 10 || collisionLayer == 11)
            {
                print("collided with floor");
                Destroy(this.gameObject);
            }
        }
    }
}
