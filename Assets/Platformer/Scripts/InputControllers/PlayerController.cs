using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/Player Controller")]
public class PlayerController : InputController
{
    private Player player;

    public override void Initialize(GameObject obj)
    {
        player = obj.GetComponent<Player>();
    }

    public override void ProcessInput(GameObject obj)
    {
        float moveX;
        float moveY = player.rb.velocity.y;

        // calculate horizontal movement
        moveX = Input.GetAxisRaw("Horizontal") * player.walkSpeed;
        player.Movement(new Vector2(moveX, moveY));

        if ((player.facingRight == true && moveX < 0) || (player.facingRight == false && moveX > 0))
        {
            player.Flip();
        }

        // calculate vertical movement
        if (Input.GetButtonDown("Jump") && player.numJump < player.maxJumps)
        {
            player.Jump();
        }
    }
}