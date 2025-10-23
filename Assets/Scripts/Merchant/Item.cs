using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEditor.Build;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject reference, reference_broke;
    [SerializeField]
    private LayerMask Layer;
    private GameObject hint, broke;
    public int price;
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        if(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1, Layer))
        {
            if (Input.GetKeyDown(KeyCode.E) && script.money > price)
            {
                script.money -= price;
                Destroy(hint);
                script.addToInventory(name);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if(script.money < price)
            {
                broke = Instantiate(reference_broke);
                broke.transform.position = transform.position + new Vector3(0, 1, 0);
            }
            else
            {
                hint = Instantiate(reference);
                hint.transform.position = transform.position + new Vector3(0, 1, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");
        PlayerScript script = player.GetComponent<PlayerScript>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (script.money < price)
            {
                Destroy(broke);
            }
            else
            {
                Destroy(hint);
            }
        }
    }
}
