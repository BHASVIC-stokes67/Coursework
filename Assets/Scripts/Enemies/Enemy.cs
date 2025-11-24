using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed = 7f, damage = 5;
    public float health = 7;
    [SerializeField]
    public Rigidbody2D body;
    [SerializeField]
    public SpriteRenderer sprite;

    void Start()
    {
        body = body.GetComponent<Rigidbody2D>();
        sprite = sprite.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(sprite.flipX == false)
        {
            body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
        }
        else
        {
            body.linearVelocity = new Vector2(-speed, body.linearVelocity.y);
        }
        die();
    }

    public void die()
    {
        if (health <= 0)
        {
            GameObject player = GameObject.Find("Player");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.money += 50;
            Destroy(this.gameObject);
        }
    }
}
