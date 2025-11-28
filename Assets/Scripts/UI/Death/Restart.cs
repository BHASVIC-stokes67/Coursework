using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSpawn;
    [SerializeField]
    private GameObject playerRef;
    private GameObject player;

    //Respawns player. This can only be accessed from the death screen
    public void SpawnPlayer()
    {
        Transform point = playerSpawn.GetComponent<Transform>();
        player = Instantiate(playerRef);
        player.name = "Player";
        player.transform.position = new Vector3(point.position.x, point.position.y, 0);
    }
}
