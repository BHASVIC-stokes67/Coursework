using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Gunner : Enemy
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private GameObject bulletRef;
    private GameObject bullet;
    [SerializeField]
    private Transform location;
    private float attackSpeed;

    void Update()
    {
        Shoot();
        die();
    }

    private void Shoot()
    {
        if (Time.time > attackSpeed)
        {
            bullet = Instantiate(bulletRef);
            e_bullet bulletScript = bullet.GetComponent<e_bullet>();
            if (sprite.flipX == false)
            {
                bullet.transform.position = location.position + new Vector3(1, 0, 0);
                bulletScript.damage = damage;
                bulletScript.speed = 20;
            }
            else
            {
                bullet.transform.position = location.position + new Vector3(-1, 0, 0);
                bulletScript.damage = damage;
                bulletScript.speed = -20;
            }
            attackSpeed = Time.time + 1f;
        }
    }
}
