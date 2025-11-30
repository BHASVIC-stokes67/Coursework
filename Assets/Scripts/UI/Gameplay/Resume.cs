using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    private GameObject controllerReference;
    public void Unpause()
    {
        Pause unPause = controllerReference.GetComponent<Pause>();
        unPause.isPaused = false;
    }
}
