using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPink : MonoBehaviour {
    public float speed;
    public Transform[] spots;
    private int randomSpot;
    
    private Vector3 previousPosition;
    private Animator animator;
    
	
	void Start () {
        randomSpot = UnityEngine.Random.Range(0, spots.Length);
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
        
	}


    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, spots[randomSpot].position, speed * Time.deltaTime);
        Vector3 direction = transform.position - previousPosition;
        previousPosition = transform.position;
        if (Vector2.Distance(transform.position, spots[randomSpot].position) < 0.2f)
        {
            
            randomSpot = UnityEngine.Random.Range(0, spots.Length);
        }
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
