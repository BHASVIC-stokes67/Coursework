using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    public void Enter_Game()
    {
        SceneManager.LoadScene("Gameplay");
        print("Started game");
    }
}
