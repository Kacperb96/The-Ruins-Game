using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletPower;

    public void InitializeBullet(float power)
    {
        bulletPower = power;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Stats>() != null)
        {
            collision.gameObject.GetComponent<Stats>().GetDamage(bulletPower);
        }
        Destroy(gameObject);
    }
}