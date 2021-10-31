using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    int gridWidth;
    int gridHeight;

    Dictionary<Vector2Int, Vector2Int> grid;

    public PathFinder(int _width, int _height)
    {
        gridWidth = _width;
        gridHeight = _height;

        grid = new Dictionary<Vector2Int, Vector2Int>();

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                grid.Add(new Vector2Int(x, y), new Vector2Int(x, y));
            }
        }
    }

    public List<Vector2Int> FindPath(Vector2Int startNode, Vector2Int endNode, int pathLength, List<Vector2Int> forbiddenNodes)
    {
        // the path has moved too far away, or path cannot be found
        int manhattanDistance = Mathf.Abs(startNode.x - endNode.x) + Mathf.Abs(startNode.y - endNode.y);
        if (manhattanDistance > pathLength || manhattanDistance % 2 != pathLength % 2)
        {
            return null;
        }

        if (pathLength > 0 || startNode != endNode)
        {
            List<Vector2Int> neighborNodes = new List<Vector2Int>();
            if (grid.ContainsKey(new Vector2Int(startNode.x, startNode.y + 1)))
            {
                neighborNodes.Add(grid[new Vector2Int(startNode.x, startNode.y + 1)]);
            }
            if (grid.ContainsKey(new Vector2Int(startNode.x + 1, startNode.y)))
            {
                neighborNodes.Add(grid[new Vector2Int(startNode.x + 1, startNode.y)]);
            }
            if (grid.ContainsKey(new Vector2Int(startNode.x, startNode.y - 1)))
            {
                neighborNodes.Add(grid[new Vector2Int(startNode.x, startNode.y - 1)]);
            }
            if (grid.ContainsKey(new Vector2Int(startNode.x - 1, startNode.y)))
            {
                neighborNodes.Add(grid[new Vector2Int(startNode.x - 1, startNode.y)]);
            }

            // randomize which neighborNodes to visit first
            neighborNodes = ShuffleList(neighborNodes);

            List<Vector2Int> newForbiddenNodes = new List<Vector2Int>(forbiddenNodes)
            {
                startNode
            };

            foreach (Vector2Int neighbor in neighborNodes)
            {
                if (!newForbiddenNodes.Contains(neighbor))
                {
                    List<Vector2Int> currentPath = new List<Vector2Int>();
                    currentPath = FindPath(neighbor, endNode, pathLength - 1, newForbiddenNodes);
                    if (currentPath != null)
                    {
                        currentPath.Add(startNode);
                        return currentPath;
                    }
                }
            }
        }
        else if (pathLength == 0 && startNode == endNode)
        {
            // path has made it to the end
            List<Vector2Int> currentPath = new List<Vector2Int>
            {
                startNode
            };
            return currentPath;
        }
        return null;
    }

    // from https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/#post-7501124
    private List<Vector2Int> ShuffleList(List<Vector2Int> inputList)
    {
        //take any list of GameObjects and return it with Fischer-Yates shuffle
        int i = 0;
        int t = inputList.Count;
        int r = 0;
        Vector2Int p;
        List<Vector2Int> tempList = new List<Vector2Int>();
        tempList.AddRange(inputList);

        while (i < t)
        {
            r = Random.Range(i, tempList.Count);
            p = tempList[i];
            tempList[i] = tempList[r];
            tempList[r] = p;
            i++;
        }

        return tempList;
    }
}
