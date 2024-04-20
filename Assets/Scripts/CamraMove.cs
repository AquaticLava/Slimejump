using System.Collections;
using System.Collections.Generic;
using UnityEngine;public class CameraMove : MonoBehaviour
{
    public Transform pointA;
    public float speed = 2f;
    public bool move = true;
    private Transform currentTarget;    void Start()
    {
        if (move)
        {
            // Initialize the current target based on the defined points
            if (pointA != null)
                currentTarget = pointA;
        }
    }    void Update()
    {
        if (move)
        {
            if (Vector3.Distance(transform.position, currentTarget.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
            }
            else move = false;
        }
    }
}