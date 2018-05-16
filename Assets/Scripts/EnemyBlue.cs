using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBlue : MonoBehaviour {
    public Transform[] spots;
    public float speed;
    public int spotNumber;
    private Animator animator;
    
    private Vector3 previousPosition;

    void Start () {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
	}
	
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, spots[spotNumber].position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, spots[spotNumber].position) < 0.2f)
        {
            if (spotNumber > spots.Length)
            {
                spotNumber = 0;
            }
            spotNumber++;
        }
       

        Vector3 direction = transform.position - previousPosition;
        previousPosition = transform.position;
        if (direction.x > 0 && Math.Abs(direction.x) > Math.Abs(direction.y))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Down", false);
            animator.SetBool("Up", false);
            animator.SetBool("Right", true);
        }
        else if (direction.y > 0 && Math.Abs(direction.y) > Math.Abs(direction.x))
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
