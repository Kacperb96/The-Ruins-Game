using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger ("fail");
        }
    }
}