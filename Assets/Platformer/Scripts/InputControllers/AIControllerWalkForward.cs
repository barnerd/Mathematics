using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/AI/Walk Forward")]
public class AIControllerWalkForward : InputController
{
    private Character character;
    private CharacterMotor motor;

    public bool canTurnAround;

    public override void Initialize(GameObject obj)
    {
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
    }
}