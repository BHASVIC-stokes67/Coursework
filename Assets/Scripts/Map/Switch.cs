using NUnit.Framework.Constraints;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    private bool isFlipped = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer SR = platform.GetComponent<SpriteRenderer>();
        PlatformEffector2D PF2D = platform.GetComponent<PlatformEffector2D>();
        int collisionLayer = collision.gameObject.layer;
        if(collisionLayer == 6)
        {
            if(Input.GetKeyDown("Q"))
            {
                if(!isFlipped)
                {
                    SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
                    PF2D.surfaceArc = -90;
                }
                else
                {
                    SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
                    PF2D.surfaceArc = 90;
                }
                isFlipped = !isFlipped;
            }
        }
    }
}
