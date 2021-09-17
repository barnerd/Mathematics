using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;

    public float jumpHeight;

    public InputController currentController;
    public Rigidbody2D rb;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public int maxJumps;
    public int numJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentController.Initialize(gameObject);

        numJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            numJump = 0;
        }
    }

    // FixedUpdate is used with physics
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        currentController.ProcessInput(gameObject);
    }

    public void Movement(Vector2 move, Vector2 velocity)
    {
        rb.position += move;
        rb.velocity += velocity;
    }
}
