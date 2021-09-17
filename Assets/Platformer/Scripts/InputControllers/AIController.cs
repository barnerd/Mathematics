using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController", menuName = "Input Controller/AI Controller")]
public class AIController : InputController
{
    //public float thresholdToPaddle;
    //public float heightToFocusOnBall;
    //public float waitTimeToReleaseBall;

    private Player player;
    private Collider2D playerCollider;

    public override void Initialize(GameObject obj)
    {
        player = obj.GetComponent<Player>();
        playerCollider = obj.GetComponent<Collider2D>();
    }

    public override void ProcessInput(GameObject obj)
    {
    }
}