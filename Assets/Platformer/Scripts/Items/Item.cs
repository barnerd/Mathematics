using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public bool useSprite;
    public Sprite image;
    public string displayText;
    public int numPoints;

    public IntReference gameScore;
    public IntReference scoreMultiplier;

    public GameEvent _event;

    public virtual void CollectItem()
    {
        // add score for collecting Item
        gameScore.Value += numPoints * scoreMultiplier.Value;

        // spawn a cool effect
        if (_event != null)
        {
            _event.Raise(this);
        }
    }
}
