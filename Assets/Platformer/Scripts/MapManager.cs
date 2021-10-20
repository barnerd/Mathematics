using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Vector2 offset; // how far to offset the top left block
    private float gridWidth, gridHeight; // dimensions of each block

    public GameObject block;
    public GameObject endGoal;

    private Vector2Int spawnPoint;
    private Vector2Int endGoalLocation;

    public ItemPickup itemPU;
    public ItemSet operatorsSet;
    public Player player;

    public IntReference score;

    // Start is called before the first frame update
    void Start()
    {
        gridWidth = block.GetComponent<SpriteRenderer>().bounds.size.x;
        gridHeight = block.GetComponent<SpriteRenderer>().bounds.size.y;

        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 ConvertGridToVector(int _x, int _y)
    {
        return new Vector3(offset.x + _x * gridWidth, offset.y - _y * gridHeight, 0);
    }

    private Vector3 ConvertGridToVector(Vector2Int _point)
    {
        return ConvertGridToVector(_point.x, _point.y);
    }

    private void CreatePowerup(GameObject _pu, Item _i, int _x, int _y)
    {
        GameObject newGameObject = Instantiate(_pu, ConvertGridToVector(_x, _y), Quaternion.identity);
        newGameObject.transform.SetParent(this.transform, false);

        ItemPickup newItemPickup = newGameObject.GetComponent<ItemPickup>();
        newItemPickup.item = _i;
    }

    private void CreateBlock(GameObject _b, int _x, int _y)
    {
        GameObject newBlock = Instantiate(_b, ConvertGridToVector(_x, _y), Quaternion.identity);
        newBlock.transform.parent = this.transform;
    }

    private void CreatePlatform(GameObject _b, int _x, int _y, int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            CreateBlock(_b, _x + i, _y);
        }
    }

    private void CreatePyramid(GameObject _b, int _x, int _y, int _length, bool _forward, bool _top)
    {
        for (int y = 0; y < _length; y++)
        {
            if (y != _length - 1 || (y == _length - 1 && _top))
            {
                for (int x = 0; x < _length - y; x++)
                {
                    CreateBlock(_b, _x + x * ((_forward) ? 1 : -1), _y - y);
                }
            }
        }
    }

    private void StartLevel()
    {
        CreateLevel();

        // reset level score
        score.Value = 0;

        // reset collection for level
        operatorsSet.ResetCollection();

        player.transform.position = ConvertGridToVector(spawnPoint);
    }

    private void CreateLevel()
    {
        spawnPoint = new Vector2Int(3, 14);
        endGoalLocation = new Vector2Int(200, 14);

        //first mario level
        //ground
        CreatePlatform(block, 0, 15, 69);
        CreatePlatform(block, 0, 16, 69);

        CreatePlatform(block, 71, 15, 16);
        CreatePlatform(block, 71, 16, 16);

        CreatePlatform(block, 90, 15, 66);
        CreatePlatform(block, 90, 16, 66);

        CreatePlatform(block, 158, 15, 45);
        CreatePlatform(block, 158, 16, 45);

        CreateBlock(block, 17, 11);
        CreatePlatform(block, 21, 11, 5);
        CreateBlock(block, 23, 7);

        CreatePowerup(itemPU.gameObject, operatorsSet.itemsInSet[0], 17, 10);
        CreatePowerup(itemPU.gameObject, operatorsSet.itemsInSet[1], 23, 6);
        CreatePowerup(itemPU.gameObject, operatorsSet.itemsInSet[2], 35, 7);
        CreatePowerup(itemPU.gameObject, operatorsSet.itemsInSet[3], 46, 14);
        // first pipe
        CreateBlock(block, 29, 13);
        CreateBlock(block, 29, 14);
        CreateBlock(block, 30, 13);
        CreateBlock(block, 30, 14);

        // second pipe
        CreateBlock(block, 39, 13);
        CreateBlock(block, 39, 14);
        CreateBlock(block, 40, 13);
        CreateBlock(block, 40, 14);

        // third pipe
        CreateBlock(block, 47, 12);
        CreateBlock(block, 47, 13);
        CreateBlock(block, 47, 14);
        CreateBlock(block, 48, 12);
        CreateBlock(block, 48, 13);
        CreateBlock(block, 48, 14);

        // forth pipe
        CreateBlock(block, 58, 12);
        CreateBlock(block, 58, 13);
        CreateBlock(block, 58, 14);
        CreateBlock(block, 59, 12);
        CreateBlock(block, 59, 13);
        CreateBlock(block, 59, 14);

        CreatePlatform(block, 78, 11, 3);
        CreatePlatform(block, 81, 7, 8);
        CreatePlatform(block, 92, 7, 4);
        CreatePlatform(block, 95, 11, 1);

        CreatePlatform(block, 101, 11, 2);
        CreatePlatform(block, 107, 11, 1);
        CreatePlatform(block, 111, 11, 1);
        CreatePlatform(block, 111, 7, 1);
        CreatePlatform(block, 115, 11, 1);
        CreatePlatform(block, 121, 11, 1);

        CreatePlatform(block, 127, 7, 3);

        CreatePlatform(block, 131, 7, 4);
        CreatePlatform(block, 132, 11, 2);

        CreatePyramid(block, 140, 14, 4, false, true);
        CreatePyramid(block, 143, 14, 4, true, true);

        CreatePyramid(block, 155, 14, 5, false, false);
        CreatePyramid(block, 158, 14, 4, true, true);

        // fifth pipe
        CreateBlock(block, 164, 13);
        CreateBlock(block, 164, 14);
        CreateBlock(block, 165, 13);
        CreateBlock(block, 165, 14);

        CreatePlatform(block, 169, 11, 4);

        // six pipe
        CreateBlock(block, 180, 13);
        CreateBlock(block, 180, 14);
        CreateBlock(block, 181, 13);
        CreateBlock(block, 181, 14);

        CreatePyramid(block, 190, 14, 9, false, false);
    }
}
