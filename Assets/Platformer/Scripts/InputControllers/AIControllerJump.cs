using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/AI/Jump")]
public class AIControllerJump : InputController
{
    private Character character;
    private CharacterMotor motor;

    public float jumpDelay;
    // TODO: add randomness to jumpDelay, i.e. 5-10% of jumpDelay, so 90-110%

    public override void Initialize(GameObject obj)
    {
        obj.GetComponent<CharacterMotor>().nextTimeForAIUpdate = Time.time + jumpDelay;
    }

    public override void ProcessInput(GameObject obj)
    {
        character = obj.GetComponent<Character>();
        motor = character.GetComponent<CharacterMotor>();

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

        /*if (always face player)
        {
            motor.Flip();
        }*/
    }
}