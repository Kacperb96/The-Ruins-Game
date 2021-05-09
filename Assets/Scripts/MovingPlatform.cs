using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform navStartPoint;
    public Transform navEndPoint;
    public float speed;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 currPlatformPosition;

    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    void Update()
    {
        currPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currPlatformPosition;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
            other.attachedRigidbody.Sleep();
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}