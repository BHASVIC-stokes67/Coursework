using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player = GameObject.Find("Player");
    private Transform p_Location = player.GetComponent<Transform>();
    private Transform location;
    void Update()
    {
        location.position = new Vector3()
    }
}
