using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField]
    private GameObject pauseUI;
    void Update()
    {
        pauseUI.SetActive(isPaused);
        if(Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;
        }
        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
