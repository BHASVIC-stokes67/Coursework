using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject hint;
    private GameObject copy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            copy = Instantiate(hint);
        }
        else
        {
            try
            {
                Destroy(copy);
            }
            catch
            {
                print("Attemted to delete hint");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(copy);
        }
    }
}
