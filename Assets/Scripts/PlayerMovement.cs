using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*  This class accepts user input to create player movement and align it with
 *  the player animation.
 *  This script is a component of the Player.
 *  Alexandra Collier-Lake
 *  May 15, 2023
 */
public class PlayerMovement : MonoBehaviour
{

    private float turnSpeed;
    private Animator animator;
    private Rigidbody rb;
    private Quaternion rotation;
    private Vector3 movement;
    private AudioSource audioSource;
    private int score;
    private GameObject item;
    private GameObject item1;
    private GameObject item2;
    private GameObject item3;
    private GameObject item4;
    [SerializeField] TextMeshProUGUI scoreText;
    



    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 20f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rotation = Quaternion.identity;
        movement = Vector3.zero;
        audioSource = GetComponent<AudioSource>();
        score = 0;
        item = GameObject.Find("item");
        item1 = GameObject.Find("item(1)");
        item2 = GameObject.Find("item(2)");
        item3 = GameObject.Find("item(3)");
        item4 = GameObject.Find("item(4)");
        UpdateScore();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetMovement();
        SetIsWalking();
        SetRotation();
    }

    // Sets the value of movement based on user input
    private void SetMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal, 0f, vertical);
    }

    // Sets the value of the IsWalking parameter in the Animator based on the value of the movement
    private void SetIsWalking()
    {
        if (Mathf.Approximately(movement.magnitude, 0f))
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
            if (audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    // Sets the value of rotation based on the value of the movement
    private void SetRotation()
    {
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
    }

    // Moves and rotates the player based on an event from the Animator
    private void OnAnimatorMove()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Collectable")
        {
           
            score++;
            UpdateScore();
            other.GetComponent<AudioSource>().Play();
            StartCoroutine(PlayAudioThenDestroy(other.gameObject));
           

        }
        
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator PlayAudioThenDestroy(GameObject other)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(other);
    }
}
