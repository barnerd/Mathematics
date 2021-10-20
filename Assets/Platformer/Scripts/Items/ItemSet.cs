using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSet", menuName = "Items/Collection")]
public class ItemSet : ScriptableObject
{
    public IntReference score;

    public CollectionItem[] itemsInSet;
    public bool[] collected;
    private int numCollected;

    public int completionPoints;

    public void UpdateCollection(ScriptableObject _item)
    {
        for (int i = 0; i < itemsInSet.Length; i++)
        {
            if (itemsInSet[i] == (CollectionItem)_item)
            {
                collected[i] = true;
                numCollected++;
            }
        }

        if(numCollected == itemsInSet.Length)
        {
            score.Value += completionPoints;
            // run special animation & sounds
        }
    }

    public void ResetCollection()
    {
        for (int i = 0; i < itemsInSet.Length; i++)
        {
            collected[i] = false;
        }

        numCollected = 0;
    }
}
