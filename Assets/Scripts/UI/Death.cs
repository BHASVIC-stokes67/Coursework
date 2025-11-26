using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private GameObject deadUI;


    void Update()
    {
        if(HasDied())
        {
            deadUI.SetActive(true);
        }
    }

    //Checks if the player has died
    public bool HasDied()
    {
        if(GameObject.Find("Player") == null)
        {
            return true;
        }
        return false;
    }
}
