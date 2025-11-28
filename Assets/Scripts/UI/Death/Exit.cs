using UnityEngine;
using UnityEditor;

public class Exit : MonoBehaviour
{
    //Exits the game
    public void Close_The_Game()
    {
        EditorApplication.isPlaying = false;
    }
}
