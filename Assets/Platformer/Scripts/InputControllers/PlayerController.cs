using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/Player Controller")]
public class PlayerController : InputController
{
    private Player player;
    private Collider2D playerCollider;

    public override void Initialize(GameObject obj)
    {
        player = obj.GetComponent<Player>();
        playerCollider = obj.GetComponent<Collider2D>();
    }

    public override void ProcessInput(GameObject obj)
    {
        Vector2 move = Vector2.zero;
        Vector2 velocity = Vector2.zero;

        // calculate horizontal movement
        move += Vector2.right * Input.GetAxisRaw("Horizontal") * player.walkSpeed * Time.deltaTime;

        // calculate vertical movement
        if (Input.GetButtonDown("Jump") && player.numJump < player.maxJumps)
        {
            velocity += Vector2.up * player.jumpHeight;
            player.numJump++;
        }

        player.Movement(move, velocity);

        /*
        // Controls on a keyboard
        // move paddle Left
        if (Input.GetKey(moveLeft))
        {
            paddle.MoveLeft();
        }
        // move paddle Right
        else if (Input.GetKey(moveRight))
        {
            paddle.MoveRight();
        }
        else if (paddle.heldBall != null && paddle.ballHeld && Input.GetKeyUp(releaseBall))
        {
            paddle.heldBall.ReleaseBall();
            paddle.ballHeld = false;
            paddle.heldBall = null;
        }

        // Controls on a touchscreen
        if (Input.touchCount > 0)
        {
            paddleCenter = paddleCollider.bounds.center;
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);

            if (touchPosition.x < paddleCenter.x)
            {
                paddle.MoveLeft();
            }
            else if (touchPosition.x > paddleCenter.x)
            {
                paddle.MoveRight();
            }
            if (paddle.heldBall != null && paddle.ballHeld && touch.phase == TouchPhase.Began)
            {
                paddle.heldBall.ReleaseBall();
                paddle.ballHeld = false;
                paddle.heldBall = null;
            }
        }
        */
    }
}