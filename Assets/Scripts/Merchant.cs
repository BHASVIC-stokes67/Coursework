using System.Xml.Serialization;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private string[] possibleItems = new string[] { "Ace", "Monter", "Broken Sword", "Gun" }, inventory;
    private int[] prices;
    private int index;
    [SerializeField]
    private GameObject[] itemRef;
    private GameObject item;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            prices[i] = Random.Range(50, 200);
            inventory[i] = possibleItems[Random.Range(0, possibleItems.Length)];
        }
    }

    private void MakeItem()
    {
        index = Random.Range(0, itemRef.length);
    }
}
