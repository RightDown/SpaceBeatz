﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Transform rightPoint;
    public Transform leftPoint;
    private Vector2 target;
    private Animator anim;
    private bool moving = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        target = rightPoint.position;
    }

    void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();
        else if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        #endif

        if ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if((Vector2)transform.position == target)
            {
                anim.SetBool("Rocket_rotate_right", false);
                anim.SetBool("Rocket_rotate_left", false);
                moving = false;
            }
        }
    }

    public void MoveRight()
    {
        if(transform.position != rightPoint.position && !moving)
        {
            target = rightPoint.position;
            anim.SetBool("Rocket_rotate_right", true);
            anim.SetBool("Rocket_rotate_left", false);
            moving = true;
        }
    }
    public void MoveLeft()
    {
        if (transform.position != leftPoint.position && !moving)
        {
            target = leftPoint.position;
            anim.SetBool("Rocket_rotate_left", true);
            anim.SetBool("Rocket_rotate_right", false);
            moving = true;
        } 
    }
}
