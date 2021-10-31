using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Maps/MapData")]
public class MapData : ScriptableObject
{
    public string mapToLoad;
    public int seed;

    public int mapGridWidth;
    public int mapGridHeight;

    public float mapGridPathCoveragePercent; // how much of the grid is part of the solution path
    public float mapGridCoveragePercent; // how much of the grid should have rooms, some of which can be secret or not part of the solution path
}
