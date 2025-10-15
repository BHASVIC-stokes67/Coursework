using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject hint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(hint);
        }
        else
        {
            try
            {
                Destroy(hint);
            }
            catch
            {
                print("Attemted to delete hint");
            }
        }
    }

    private void OnTri(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(hint);
        }
    }
}
