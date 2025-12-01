using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D door;
    [SerializeField]
    private SpriteRenderer SR;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (door != null && collision.gameObject.layer == 6) { 
            door.enabled = true;
            SR.enabled = true;
        }
    }
}
