using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Character Data")]
public class CharacterData : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;

    public float jumpForce;

    public int damage;
    public int maxHitPoints;

    public string representation;

    public InputController controller;
}
