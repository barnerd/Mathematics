using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapSelectUI : MonoBehaviour
{
    public MapData mapData;

    public void LoadMap()
    {
        mapData.mapToLoad = GetComponentInChildren<TextMeshProUGUI>().text;

        SceneManager.LoadScene("Map");
    }
}
