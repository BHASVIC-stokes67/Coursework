using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject reference;
    [SerializeField]
    private LayerMask Player;
    [SerializeField]
    Player player;


    private GameObject hint;

    void Update()
    {
        if(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1, Player))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.addToInventory(gameObject.name);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hint = Instantiate(reference);
            hint.transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(hint);
        }
    }
}
