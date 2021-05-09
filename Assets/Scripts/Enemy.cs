using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public float bulletSpeed;
    float attackForce = 1f;
    Stats stats;

    void Start()
    {
        stats = gameObject.GetComponent<Stats>();
        InvokeRepeating("ShootBullet", 0.5f, 1f);
    }

    void Update()
    {
        
    }

    void ShootBullet()
    {
        attackForce = stats.TakeAttack();
        GameObject bullet = Instantiate (bulletPrefab, gameObject.transform);
        bullet.transform.SetParent(null);
        bullet.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
        bullet.transform.position = gameObject.transform.position;
         
        bullet.GetComponent<Bullet>().InitializeBullet(attackForce);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2 (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.1 ? bulletSpeed : -bulletSpeed, 0f), ForceMode2D.Force);
        Destroy(bullet, 2f);
        
    }
}