using UnityEngine;
using UnityEditor;

public class Exit_MM : MonoBehaviour
{
    //Exits the game
    public void Close_The_Game()
    {
        EditorApplication.isPlaying = false;
    }
}
