using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEditor.Build;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject reference;
    [SerializeField]
    private LayerMask Layer;
    private GameObject hint;

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        if(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1, Layer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                script.addToInventory(name);
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
