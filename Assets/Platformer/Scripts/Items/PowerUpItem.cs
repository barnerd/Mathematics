using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpItem", menuName = "Items/PowerUp Item")]
public class PowerUpItem : Item, IComparable<PowerUpItem>
{
    public int duration; // in seconds, negative for no duration

    public override void CollectItem()
    {
        base.CollectItem();
    }

    public int CompareTo(PowerUpItem second)
    {
        int firstValue = 0;
        int secondValue = 0;

        if (displayText == "( )")
        {
            firstValue = 3;
        }
        if (displayText == "[ ]")
        {
            firstValue = 2;
        }
        if (displayText == "{ }")
        {
            firstValue = 1;
        }
        if (second.displayText == "( )")
        {
            secondValue = 3;
        }
        if (second.displayText == "[ ]")
        {
            secondValue = 2;
        }
        if (second.displayText == "{ }")
        {
            secondValue = 1;
        }

        return secondValue - firstValue;
    }
}
