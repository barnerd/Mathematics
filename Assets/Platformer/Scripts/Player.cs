using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;

    public float jumpForce;

    public InputController currentController;
    public Rigidbody2D rb;

    public bool facingRight = true;

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

    public void Movement(Vector2 _move)
    {
        rb.velocity = _move;
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        numJump++;
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
