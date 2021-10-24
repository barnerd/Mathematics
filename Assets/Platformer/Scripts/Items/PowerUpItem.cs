using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpItem", menuName = "Items/PowerUp Item")]
public class PowerUpItem : Item
{
    public int duration; // in seconds, negative for no duration

    public override void CollectItem()
    {
        base.CollectItem();
    }
}
