using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character), typeof(Rigidbody2D))]
public class CharacterMotor : MonoBehaviour
{
    public Character character;
    public Rigidbody2D rb;

    public bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isFacingWall;
    public Transform frontCheck;
    public float frontCheckRadius;
    public LayerMask whatIsGround;

    public int maxJumps;
    public int numJump;

    [Header("timer values for AI")]
    public float nextTimeForAIUpdate;
    public bool isPatrolling;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        rb = GetComponent<Rigidbody2D>();

        numJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded || isFacingWall)
        {
            numJump = 0;
        }
    }

    // FixedUpdate is used with physics
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isFacingWall = Physics2D.OverlapCircle(frontCheck.position, frontCheckRadius, whatIsGround);
    }

    public void Movement(Vector2 _move)
    {
        rb.velocity = _move;
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * character.data.jumpForce;
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
