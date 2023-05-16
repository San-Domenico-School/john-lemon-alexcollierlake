using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  This class accepts user input to create player movement and align it with
 *  the player animation.
 *  
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets the value of movement based on user input
    private void SetMovement() { }

    // Sets the value of the IsWalking parameter in the Animator based on the value of the movement
    private void SetIsWalking() { }

    // Sets the value of rotation based on the value of the movement
    private void SetRotation() { }

    // Moves and rotates the player based on an event from the Animator
    private void OnAnimatorMove() { }

    
        
    
}
