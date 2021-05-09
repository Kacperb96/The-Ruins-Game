using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform navStartPoint;
    public Transform navEndPoint;
    public float speed;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 currEnemyPosition;
    bool dirToRitght = true;

    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    void Update()
    {
        currEnemyPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currEnemyPosition;

    }

    void Flip ()
    {
        dirToRitght = !dirToRitght;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x*=-1;
        gameObject.transform.localScale = heroScale;
    }
}