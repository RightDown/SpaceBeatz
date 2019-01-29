using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Transform rightPoint;
    public Transform leftPoint;
    private Vector2 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        target = rightPoint.position;
    }
    public void MoveLeft()
    {
        target = leftPoint.position;
    }
}
