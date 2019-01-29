using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Transform rightPoint;
    public Transform leftPoint;
    private Vector2 target;
    private Animator anim;

    void Start()
    {
        target = rightPoint.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if((Vector2)transform.position == target)
            {
                anim.SetBool("Rocket_rotate_right", false);
                anim.SetBool("Rocket_rotate_left", false);
            }
        }
    }

    public void MoveRight()
    {
        if(transform.position != rightPoint.position)
        {
            target = rightPoint.position;
            anim.SetBool("Rocket_rotate_right", true);
        }
    }
    public void MoveLeft()
    {
        if (transform.position != leftPoint.position)
        {
            target = leftPoint.position;
            anim.SetBool("Rocket_rotate_left", true);
        } 
    }
}
