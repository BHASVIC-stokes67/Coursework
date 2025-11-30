using NUnit.Framework.Constraints;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private LayerMask layer;
    private bool isFlipped = false;

    void Update()
    {
        SpriteRenderer SR = platform.GetComponent<SpriteRenderer>();
        PlatformEffector2D PF2D = platform.GetComponent<PlatformEffector2D>();
        if(Input.GetKeyDown("q") && Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.5f, layer))
        {
            if(!isFlipped)
            {
                print("Pressed q (Not flipped)");
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
                PF2D.surfaceArc = -90;
            }
            else
            {
                print("Pressed q (flipped)");
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
                PF2D.surfaceArc = 90;
            }
            isFlipped = !isFlipped;
        }
    }
}
