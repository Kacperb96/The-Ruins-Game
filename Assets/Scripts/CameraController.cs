using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject hero;
    public float smooth;
    private Vector3 currVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newCamPosition = new Vector3 (hero.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newCamPosition, ref currVelocity, smooth);        
    }
}