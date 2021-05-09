using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject gmanager;
    Stats stats;
    [SerializeField] Slider sliderHP;
    [SerializeField] Slider sliderMagic;

    void Start()
    {
        stats = GetComponent<Stats>();
        sliderHP.maxValue = stats.TakeBasicHp();
        sliderMagic.maxValue = stats.TakeBasicMagic();
    }

    void Update()
    {
        sliderHP.value = stats.TakeHP();
        sliderMagic.value = stats.TakeMagic();
        stats.RenewMagic();
        stats.RenewHp();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag ("Finish"))
        {
            gmanager.GetComponent<GameManager>().WinLevel();
        }
    }
}