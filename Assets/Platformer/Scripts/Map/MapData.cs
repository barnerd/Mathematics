using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Maps/MapData")]
public class MapData : ScriptableObject
{
    public string mapToLoad;
    public int seed;
}
