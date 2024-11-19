using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/---------- Lore ---------- /*/
/* The aim of this script will be to be a Third Person Camera. Lots of Mathematical stuff.
 * Stage 1: Lock the mouse
 * Stage 2: get mouse input and apply sensitivity to it
 * Stage 3: Change RotationY based on Mouse X input
 * Stage 4: Change RotationX based on Mouse Y input
 * Stage 5: Clamp the camera so it cannot exceed 90 degrees to -90 degrees.
 * Stage 6: Input this into the camera object. */

/*/---------- Lore ---------- /*/

public class ThirdPersonCamera : MonoBehaviour
{
    /*/ ---------- Variable Declaration(s) ---------- /*/
    public Transform Target;               // Target for the camera to follow this object.
    public float distance = 5.0f;          // Distance from this object the camera should appear.
    public float sensitivty = 2.0f;        // Sensitivity of Mouse Inputs.
    public float heightOffset = 1.5f;      // Y offset the camera should appear at.

    private float rotationX = 0f;          // Initial rotation on the X axis.
    private float rotationY = 0f;          // Initial rotation on the Y axis.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Makes sure the cursor is locked to the middle of the screen.
        Cursor.visible = false;                    // Hides the cursor.
    }

    private void Update()
    {
        HandleCameraInput();
    }
    public void HandleCameraInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivty;    // Rotate the camera on the X axis based on Y input.
        float mouseY = Input.GetAxis("Mouse Y") * sensitivty;    // Rotate the camera on the Y axis based on X input.

        rotationY += mouseX;                                    // Update the Horiztonal Position of the camera based on input.
        rotationX -= mouseY;                                    // Update the Vertical Position of the camera based on input.

        rotationX = Mathf.Clamp(rotationX, -90, 90);            // Make sure the rotation stays between -90 and 90.
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0); // Apply the camera Rotation.
    }

    public void LateUpdate() // A late update executes at the end of everything else. Useful to change the order of execution.
    {
        FollowTarget();
    }

    void FollowTarget()
    {
     /* What is any of this?
      * Stage 1: Create a new vector 3.
      * Position of Player - Front of Player * Distance (Editable), * V3.up (Above the player a little) * Offset (Editable)
      * Stage 2: Change position of the object.*/
       Vector3 targetPosition = Target.position - Target.forward * distance + Vector3.up * heightOffset;
       transform.position = targetPosition;
    }

}
 