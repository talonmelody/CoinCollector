using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/---------- Lore ---------- /*/
/* The aim of this script is to allow for the player to have WASD movement.
 * Additionally, there will be a rudimentary "Jump" mechanic to cross gaps.*/
/*/---------- Lore ---------- /*/
public class WASDMovement : MonoBehaviour
{
    /*/ ---------- Variable Declaration(s) ---------- /*/
    public float movementSpeed = 10.0f;    // Used to decide the player's movement speed.
    private Rigidbody rb;                  // Used to get the RigidBody component.
    public bool IsJumping = false;         // Used to see if the player can jump or not.
    public Vector3 Jmp;                    // Used to control the jump.
    public float JumpForce = 4.0f;         // Used to control the FORCE of the jump.
    public float mouseSensitivty = 2.0f;   // Used to decide the sensitivty of the mouse.
    private float verticalRotation = 0;    // Used to determine vertical rotation.
    private bool isGrounded = false;       // Determines if the player is on the ground or not.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    public void Start()
    {
        rb = GetComponent<Rigidbody>();          // Reference the RigidBody component attached to the Player.
        Jmp = new Vector3(0.0f, 2.0f, 0.0f);     // Sets what the jump height should be.
    }

    public void Update()
    {
        RotationInputM();
        WASDmovement();
        Jump();
    }
    
    public void WASDmovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");   // Takes HORIZONTAL input from WASD / Arrow Keys
        float moveVertical = Input.GetAxis("Vertical");       // Takes VERTICAL input from WASD / Arrow Keys
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * movementSpeed * Time.deltaTime; // Multiply the inputs by movement speed and DeltaTime
        movement = transform.TransformDirection(movement);    // Makes sure the direction is correct to use.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // Sets the velocity onto the RigidBody component.
    } 
    public void Jump()  // a rudimentary jump.
    {
        if (Input.GetKeyDown("space") && isGrounded)                       // When space is pressed
        {
            rb.AddForce(Jmp * JumpForce, ForceMode.Impulse); // Apply the force of the Jmp vector multiplied by the JumpForce float to the Rigidbody, increasing height.
            isGrounded = false;                              // So the player can't jump in the air.
        }
    }

    public void RotationInputM()                            // This script makes sure the player faces the camera's direction.
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivty;   // Multiplies Horizontal Rotation by the Mouse Sensitivity.
        transform.Rotate(0, horizontalRotation, 0);                              // Assigns to rotation
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivty;          // Inverts vertical input.
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);               // Ensures rotation stays between -90 and 90.
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Get the camera, make sure it matches vertical rotation.
    }

    void OnCollisionStay()    // If the player is on the ground, then make sure to set this to true so they can jump again.
    {
        isGrounded = true;
    }


}
