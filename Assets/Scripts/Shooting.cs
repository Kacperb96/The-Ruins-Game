using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public float bulletSpeed;
    float attackForce = 1f;
    GameObject bullet;
    float risingBulletForce = 1.5f;
    Stats stats;

    void Start()
    {
        stats = gameObject.GetComponent<Stats>();
    }

    void Update()
    {
        ShootPowerBullet();
    }

    void ShootPowerBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackForce = stats.TakeAttack();
            bullet = Instantiate (bulletPrefab, gameObject.transform);
            bullet.transform.SetParent(null);
        }
        if (Input.GetMouseButton(0))
        {
            if (GetComponent<Stats>().TakeMagic() > 0)
            {
                attackForce += risingBulletForce * Time.deltaTime;
                stats.SubtractMagic(risingBulletForce);
                bullet.transform.localScale += new Vector3 (0.3f, 0.3f, 0.3f) * risingBulletForce * Time.deltaTime;
                bullet.transform.position = gameObject.transform.position;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            bullet.GetComponent<Bullet>().InitializeBullet(attackForce);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2 (gameObject.GetComponent<Rigidbody2D>().velocity.x >= -0.1 ? bulletSpeed : -bulletSpeed, 0f), ForceMode2D.Force);
            Destroy(bullet, 2f);
        }
        
    }
}