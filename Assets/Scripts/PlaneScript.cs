using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody planeRb;
    public int planeSpeed;
    Vector3 move;
    public bool isLive = true;


    void Start()
    {
        move = new Vector3(0, 0, -1);
    }


    void FixedUpdate()
    {
        if (isLive)
        {
            planeRb.MovePosition(transform.position + move * Time.deltaTime * planeSpeed);
        }
    }
}
