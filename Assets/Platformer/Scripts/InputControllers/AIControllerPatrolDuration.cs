using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/AI/Patrol Duration")]
public class AIControllerPatrolDuration : InputController
{
    private Character character;
    private CharacterMotor motor;

    public float turnaroundDelay;
    public float patrolDuration;

    public override void Initialize(GameObject obj)
    {
        obj.GetComponent<CharacterMotor>().nextTimeForAIUpdate = Time.time + turnaroundDelay;
        obj.GetComponent<CharacterMotor>().isPatrolling = false;
    }

    public override void ProcessInput(GameObject obj)
    {
        character = obj.GetComponent<Character>();
        motor = character.GetComponent<CharacterMotor>();

        float moveX = character.data.walkSpeed * (motor.facingRight ? 1 : -1);
        float moveY = motor.rb.velocity.y;

        if (Time.time > motor.nextTimeForAIUpdate)
        {
            if (motor.isPatrolling)
            {
                motor.Movement(new Vector2(0, moveY));

                motor.nextTimeForAIUpdate += turnaroundDelay;
                motor.isPatrolling = false;
            }
            else
            {
                motor.Flip();
                motor.Movement(new Vector2(moveX, moveY));

                motor.nextTimeForAIUpdate += patrolDuration;
                motor.isPatrolling = true;
            }
        }
    }
}