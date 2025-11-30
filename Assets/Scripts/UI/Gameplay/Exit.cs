using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    //Exits the game
    public void Close_The_Game()
    {
        SceneManager.LoadScene("Main Menu");
        print("Exited game");
    }
}
