using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float speed;

    public Rigidbody2D playerRigidbody;
    
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Lives;

    private GameObject other;
    private bool FaceRight;
    private bool FaceUp;
    private int score;
    private int lives=3;
    private IEnumerator coroutine;
    private bool respawning;




    void Start ()
    {
        FaceRight = true;
        FaceUp = false;
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
            Movement(moveHorizontal, moveVertical);
            Orientation(moveHorizontal, moveVertical);
        }
        else
        {
            Movement(0, 0);
        }
    }

     private void Movement (float moveHorizontal, float moveVertical)
    {
           playerRigidbody.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        
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
            respawning = true;
        }
    }

    private void Orientation (float horizontal, float vertical)
    {
        if (!respawning)
        {

            if (horizontal > 0)
            {

                transform.localScale = new Vector3(1, 1, 1);
                transform.localRotation = Quaternion.Euler(0, 0, 0);



            }
            else if (horizontal < 0)
            {

                transform.localScale = new Vector3(-1, 1, 1);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else if (vertical > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (vertical < 0)

            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.localRotation = Quaternion.Euler(0, 0, 270);
            }
        }

    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        respawning = false;
        lives--;
    }

}
