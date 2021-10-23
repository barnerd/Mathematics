using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/Player Controller")]
public class PlayerController : InputController
{
    private Character player;
    private CharacterMotor motor;

    public override void Initialize(GameObject obj)
    {
    }

    public override void ProcessInput(GameObject obj)
    {
        player = obj.GetComponent<Character>();
        motor = player.GetComponent<CharacterMotor>();

        float moveX;
        float moveY = motor.rb.velocity.y;

        // calculate horizontal movement
        moveX = Input.GetAxisRaw("Horizontal") * player.data.walkSpeed;
        motor.Movement(new Vector2(moveX, moveY));

        if ((motor.facingRight == true && moveX < 0) || (motor.facingRight == false && moveX > 0))
        {
            motor.Flip();
        }

        // calculate vertical movement
        if (Input.GetButtonDown("Jump") && motor.numJump < motor.maxJumps)
        {
            motor.Jump();
        }
    }
}