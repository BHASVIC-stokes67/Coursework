using UnityEngine;

public class Merchant : MonoBehaviour
{
    private string[] possibleItems = new string[] { "Ace", "Monter", "Broken Sword", "Gun" }, inventory;
    private int[] prices;
    private int index;
    [SerializeField]
    private GameObject[] itemRef;
    private GameObject item;
    [SerializeField]
    private Transform location;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            prices[i] = Random.Range(50, 200);
            inventory[i] = possibleItems[Random.Range(0, possibleItems.Length)];
        }
        MakeItem();
    }

    private void MakeItem()
    {
        for(int i = 0; i < 3; i++)
        {
            index = Random.Range(0, itemRef.Length);
            item = Instantiate(itemRef[index]);
            item.transform.position = location.position + new Vector3((i * 2) + 2, 0, 0);
        }
    }
}
