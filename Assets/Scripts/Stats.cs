using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float basicAttack;
    public float basicHp;
    float attack;
    float HP;
    public float basicDefence;
    float defence;
    public float basicMagic;
    float magic;


    void Start()
    {
        HP = basicHp;
        attack = basicAttack;
        defence = basicDefence;
        magic = basicMagic;
    }

    public float TakeBasicMagic()
    {
        return basicMagic;
    }

    public float TakeBasicHp()
    {
        return basicHp;
    }

    public void GetDamage (float damage)
    {
        float finalDamage = damage - defence;
        if (finalDamage > 0)
        {
            if (HP > finalDamage)
            {
                HP -= finalDamage;
            }
            else 
            {
                Die();
            }
        }
        
    }
    
    public float TakeAttack()
    {
        return attack;
    }

    public float TakeMagic()
    {
        return magic;
    }

    public float TakeHP()
    {
        return HP;
    }

    public void SubtractMagic(float factor)
    {
        magic -= factor * Time.deltaTime;
    }

    public void RenewMagic()
    {
        if (magic < basicMagic)
        {
            magic += 0.5f * Time.deltaTime;
        }
    }

    public void RenewHp()
    {
        if (HP < basicHp)
        {
            HP += 0.2f * Time.deltaTime;
        }
    }

    void Die()
    {
        if (gameObject.transform.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}