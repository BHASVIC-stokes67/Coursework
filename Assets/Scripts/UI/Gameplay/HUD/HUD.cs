using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Pause pause;
    [SerializeField]
    private GameObject UserUI;
    [SerializeField]
    private Death death;
    void Update()
    {
        if(death.HasDied() || pause.isPaused)
        {
            UserUI.SetActive(false);
        }
        else
        {
            UserUI.SetActive(true);
        }
    }
}
