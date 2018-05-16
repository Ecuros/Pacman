using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyScript : MonoBehaviour {

    private Animator animator;
    public float speed;
    private Transform target;
   
    private Vector3 previousPosition;

    void Start () {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        previousPosition = transform.position;

	}
	
	
	void FixedUpdate ()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        Vector3 direction = transform.position - previousPosition;
        previousPosition = transform.position;
        if(direction.x >0 && Math.Abs(direction.x) > Math.Abs(direction.y))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Down", false);
            animator.SetBool("Up", false);
            animator.SetBool("Right", true);
        }
        else if(direction.y > 0 && Math.Abs(direction.y)>Math.Abs(direction.x))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Down", false);
            animator.SetBool("Up", true);

        }
        else if (direction.y < 0 && Math.Abs(direction.y) > Math.Abs(direction.x))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
        }
        else if (direction.x < 0 && Math.Abs(direction.x) > Math.Abs(direction.y))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Left", true);
        }
       

    }
}
