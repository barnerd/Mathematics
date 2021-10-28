using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;
    public string titleSceneName;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnDeath(MonoBehaviour _player)
    {
        deathUI.SetActive(true);

        Time.timeScale = 0f;

        StartCoroutine("LoadSceneRoutine");
    }

    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSecondsRealtime(delayTime);

        Time.timeScale = 1f;

        SceneManager.LoadScene(titleSceneName);
    }
}
