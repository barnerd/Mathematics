using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/AI/Walk Forward and Jump")]
public class AIControllerWalkForwardJump : InputController
{
    private Character character;
    private CharacterMotor motor;

    public bool canTurnAround;

    public float jumpDelay;

    public override void Initialize(GameObject obj)
    {
        obj.GetComponent<CharacterMotor>().nextTimeForAIUpdate = Time.time + jumpDelay;
    }

    public override void ProcessInput(GameObject obj)
    {
        character = obj.GetComponent<Character>();
        motor = character.GetComponent<CharacterMotor>();

        float moveX = character.data.walkSpeed * (motor.facingRight ? 1 : -1);
        float moveY = motor.rb.velocity.y;

        motor.Movement(new Vector2(moveX, moveY));

        if (canTurnAround && motor.isFacingWall)
        {
            motor.Flip();
        }

        if (motor.isGrounded)
        {
            if (Time.time > motor.nextTimeForAIUpdate)
            {
                motor.Jump();
            }
        }
        else
        {
            motor.nextTimeForAIUpdate = Time.time + jumpDelay;
        }
    }
}