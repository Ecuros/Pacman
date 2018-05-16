using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public float speed;

    public Rigidbody2D playerRigidbody;
    
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Lives;

    public EnemyScript redScript;
    public EnemyPink pinkScript;
    public EnemyBlue blueScript;
    

    private GameObject other;
    private int score;
    private int lives=3;
    private IEnumerator coroutine;
    private bool respawning;



    void Start ()
    {
        
        other = GameObject.Find("Food");
        respawning = false;
        
        
	}
	
	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Score.text = "SCORE: " + score.ToString();
        Lives.text = "LIVES: " + lives.ToString();


        if (!respawning)
        {
            
            
            Movement();
            Orientation();
            redScript.enabled = true;
            pinkScript.enabled = true;
            blueScript.enabled = true;
            
           
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, 0);
        }
        if(score ==71)
        {
            SceneManager.LoadScene(3);
        }
        if(lives==0)
        {
            SceneManager.LoadScene(2);
        }
    }

     private void Movement ()
    {
           
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.velocity = new Vector2(0, 1 * speed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.velocity = new Vector2(1 * speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.velocity = new Vector2(-1*speed, 0);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.velocity = new Vector2(0 , -1 * speed);
        }
        


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Destroy(other);
            Destroy(other.GetComponent<SpriteRenderer>());
            score++;
        }
        if (other.tag =="Enemy")
        {
            
            StartCoroutine(Respawn());
            redScript.enabled = false;
            pinkScript.enabled = false;
            blueScript.enabled = false;
            respawning = true;
        }
    }

    private void Orientation ()
    {
        
        if (!respawning)
        {

            if (Input.GetKeyDown(KeyCode.D))
            {

                transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);



            }
            else if (Input.GetKeyDown(KeyCode.A))
            {

                transform.localScale = new Vector3(-0.85f, 0.85f, 0.85f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.S))

            {
                transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                transform.localRotation = Quaternion.Euler(0, 0, 270);
            }
        }

    }
    private IEnumerator Respawn()
    {
        if (lives != 1)
        {
            yield return new WaitForSeconds(3f);
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            redScript.transform.position = new Vector3(3.19f, -5.0f, 0.0f);
            pinkScript.transform.position = new Vector3(-5.0f, 2.0f, 0.0f);
            blueScript.transform.position = new Vector3(1.0f,1.0f, 0.0f);
            blueScript.spotNumber = 0;
            respawning = false;
        }
        lives--;
    }


}
