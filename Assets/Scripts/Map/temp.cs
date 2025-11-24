using Unity.VisualScripting;
using UnityEngine;

public class temp : MonoBehaviour
{
    private SpriteRenderer SR;
    void Update()
    {
        SR = GetComponent<SpriteRenderer>();
        if(Input.GetKeyDown("q"))
        {
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
        }
    }
}
