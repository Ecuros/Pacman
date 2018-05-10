using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();

	}
	
	
	void FixedUpdate ()
    {








		if(Input.GetKeyDown(KeyCode.O))
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetFloat("Speed", 2.0f);
        }
        
	}
}
