using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementScript : MonoBehaviour
{
    public float speed = 5f;
    // Used to control sprinting 
    public static bool isSprinting = false;
    public static float sprintFactor = 1.5f;
    // Used to control sneaking
    public static bool isSneaking = false;
    public static float sneakFactor = 0.5f;
    public float verticalMovement;
    public float horizontalMovement;
    public Rigidbody rb;

    // Check if player is touching the ground
    public bool isGrounded;

    // How high the player can jump
    public float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Checks if rigidbody has been added and adds it if needed
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        // Prevents player rotation in the wrong direction
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jumpPlayer();
        sprintPlayer();
        sneakPlayer();
    }

    void sprintPlayer()
    {
        if (Keyboard.current.leftCtrlKey.isPressed && !isSprinting)
        {
            speed *= sprintFactor;
            isSprinting = true;
        }
        else
        {
            if (isSprinting == true)
            {
                isSprinting = false;
                speed /= sprintFactor;
            }
        }
    }

    // Logic for Sneaking
    void sneakPlayer()
    {
        if (Keyboard.current.leftShiftKey.isPressed && !isSneaking)
        {
            speed *= sneakFactor;
            isSneaking = true;
        }
        else
        {
            if (isSneaking == true)
            {
                isSneaking = false;
                speed /= sneakFactor;
            }
        }
    }

    // Logic for jumping
    void jumpPlayer()
    {
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {

            isGrounded = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }
    // Player Movement Logic
    void movePlayer()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * verticalMovement + transform.right * horizontalMovement;
        transform.position += move * speed * Time.deltaTime;

    }
    public void OnCollisionEnter(Collision collision)
    {

        // Debug.Log("Collided");
        // Prevents Double Jumps
        isGrounded = true;

    }
}
