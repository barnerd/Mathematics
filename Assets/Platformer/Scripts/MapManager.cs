using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Vector2 offset; // how far to offset the top left block
    private float gridWidth, gridHeight; // dimensions of each block

    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        gridWidth = block.GetComponent<SpriteRenderer>().bounds.size.x;
        gridHeight = block.GetComponent<SpriteRenderer>().bounds.size.y;


        for (int i = 0; i < 1; i++)
        {
            CreateBlock(block, i, 0);
        }

        for (int i = 0; i < 3; i++)
        {
            CreateBlock(block, i, 2);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateBlock(block, i, 4);
        }

        for (int i = 0; i < 7; i++)
        {
            CreateBlock(block, i, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBlock(GameObject _b, int _x, int _y)
    {
        GameObject newBlock = Instantiate(_b, new Vector3(offset.x + _x * gridWidth, offset.y - _y * gridHeight, 0), Quaternion.identity);
        newBlock.transform.parent = this.transform;
    }
}
