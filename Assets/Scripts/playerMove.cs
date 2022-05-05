using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{

    public float speed = 5.0f;
    

    private AudioSource audioSource;
    public AudioClip hopClip;
    public AudioClip squishClip;

    public float moveDuration = 0.5f;
    private float timeElapsed;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public float moveMultiplier = 0.5f;

    public enum MovementType
    {
        Continous,
        Discrete,
    }
    public MovementType movementType;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementType == MovementType.Continous)
        {
            ContinousMovement();
        } 
        else
        {
            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SetTargetPosition("Up");
                    audioSource.PlayOneShot(hopClip);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SetTargetPosition("Left");
                    audioSource.PlayOneShot(hopClip);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SetTargetPosition("Down");
                    audioSource.PlayOneShot(hopClip);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    SetTargetPosition("Right");
                    audioSource.PlayOneShot(hopClip);
                }
            }
                if (targetPosition != transform.position)
                {
                    isMoving = true;
                    DiscreteMovement(transform.position, targetPosition);
                }
                else
                {
                    isMoving = false;
                }
            
        }
        
    }

    private void SetTargetPosition(string direction)
    {
        if (direction == "Up")
        {
            targetPosition = transform.position + (Vector3.up * moveMultiplier);
        }
        if (direction == "Left")
        {
            targetPosition = transform.position + (Vector3.left * moveMultiplier);
        }
        if (direction == "Down")
        {
            targetPosition = transform.position + (Vector3.down * moveMultiplier);
        }
        if (direction == "Right")
        {
            targetPosition = transform.position + (Vector3.right * moveMultiplier);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Area Cleared");

            SceneManager.LoadScene("MovementScene");
        }
    }

    private void ContinousMovement()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        float xMovement = xMove * speed * Time.deltaTime;
        float yMovement = yMove * speed * Time.deltaTime;

        transform.Translate(xMovement, yMovement, 0);

    }

    private void DiscreteMovement(Vector3 start, Vector3 end)
    {
        timeElapsed += Time.deltaTime;

        transform.position = Vector3.Lerp(start, end, timeElapsed / moveDuration);

        if (timeElapsed >= moveDuration)
        {
            transform.position = targetPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       //destroys player when it collides with car
        if (collision.gameObject.tag == "Car")
        {
            audioSource.PlayOneShot(squishClip);
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
