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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        if (collisionLayer == 6 || collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("Wall"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerScript.health -= damage;
                print("collided with player");
            }
            if(collision.gameObject.CompareTag("floor"))
            {
                print("collided with floor");
            }
            Destroy(this.gameObject);
        }
    }
}
