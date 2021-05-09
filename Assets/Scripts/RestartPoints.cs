using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoints : MonoBehaviour
{
    RestartPointsManager restartPointsMenager;
    SpriteRenderer sprRenderer;
    Stats stats;
    
    void Start()
    {
        stats = GetComponent<Stats>();
        restartPointsMenager = GameObject.Find("Manager").GetComponent<RestartPointsManager>();
        if (restartPointsMenager == null)
        {
            Debug.LogError("Not Found");
        }
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            restartPointsMenager.UpdateStartPoint(this.gameObject.transform);
            sprRenderer.color = new Color(0.9797273f, 1f, 0f);
        }
    }
}