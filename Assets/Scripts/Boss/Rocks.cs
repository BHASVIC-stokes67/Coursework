using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D hitbox;
    private LayerMask layer;
    public float damage;
    private bool stopAttacking = true;

    void Update()
    {
        if(stopAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        stopAttacking = false;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        layer = collision.gameObject.layer;
        GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        if (layer == 6)
        {
            print("colliding with player");
            playerScript.health -= damage;
            body.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        }
    }
}
