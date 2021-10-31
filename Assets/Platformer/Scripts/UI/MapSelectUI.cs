using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapSelectUI : MonoBehaviour
{
    public MapData mapData;
    public int seed;

    public void LoadMap()
    {
        mapData.mapToLoad = GetComponentInChildren<TextMeshProUGUI>().text;
        mapData.seed = seed;

        SceneManager.LoadScene("Map");
    }
}
