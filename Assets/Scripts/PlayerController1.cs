using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigibody3D;

    [SerializeField]
    ConfigurableJoint mainJoint;

    [SerializeField]
    Animator animator;

    //input
    Vector2 moveInputVector = Vector2.zero;
    bool isJumpButtonPressed = false;

    //Controller settings
    float maxSpeed = 10;
    float rotationSpeed = 100f;

    //States
    bool isGrounded = false;

    //Raycasts
    RaycastHit[] raycastHits = new RaycastHit[10];

    //Syncing of physics objects
    SyncPhysicsObject[] SyncPhysicsObjects;

    void Awake()
    {
        SyncPhysicsObjects = GetComponentsInChildren<SyncPhysicsObject>();

        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard input for movement
        moveInputVector.x = Input.GetAxis("Horizontal"); // A/D for left/right movement
        moveInputVector.y = Input.GetAxis("Vertical");   // W/S for forward/backward movement

        // Mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");
        Quaternion currentRotation = mainJoint.targetRotation;
        Quaternion rotationDelta = Quaternion.Euler(0, -mouseX * rotationSpeed * Time.deltaTime, 0);
        mainJoint.targetRotation = currentRotation * rotationDelta;

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space))
            isJumpButtonPressed = true;
    }

    void FixedUpdate()
    {
        // Assume that we are not grounded
        isGrounded = false;

        // Check if we are grounded
        int numberofHits = Physics.SphereCastNonAlloc(rigibody3D.position, 0.1f, Vector3.down, raycastHits, 0.5f);

        for (int i = 0; i < numberofHits; i++)
        {
            // Ignore self hits
            if (raycastHits[i].transform.root == transform)
                continue;

            isGrounded = true;
            break;
        }

        // Apply extra gravity to character to make it less floaty
        if (!isGrounded)
            rigibody3D.AddForce(Vector3.down * 10);

        float inputMagnitude = moveInputVector.magnitude;

        // Calculate the movement direction
        Vector3 movementDirection = transform.forward * moveInputVector.y + transform.right * moveInputVector.x;

        // Apply movement
        if (inputMagnitude != 0)
        {
            if (rigibody3D.linearVelocity.magnitude < maxSpeed)
            {
                rigibody3D.AddForce(movementDirection.normalized * inputMagnitude * 30);
            }
        }

        // Handle jumping
        if (isGrounded && isJumpButtonPressed)
        {
            rigibody3D.AddForce(Vector3.up * 20, ForceMode.Impulse);
            isJumpButtonPressed = false;
        }

        // Update animation
        animator.SetFloat("movementSpeed", rigibody3D.linearVelocity.magnitude * 0.4f);

        // Update the joints' rotation based on the animations
        for (int i = 0; i < SyncPhysicsObjects.Length; i++)
        {
            SyncPhysicsObjects[i].UpdateJointFromAnimation();
        }
    }
}
