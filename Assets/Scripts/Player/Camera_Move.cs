using Unity.VisualScripting;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    private GameObject player;
    private Transform p_Location;
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            p_Location = player.GetComponent<Transform>();
            transform.position = new Vector3(p_Location.position.x + 1, p_Location.position.y + 1.5f, -1);
        }
    }
}
