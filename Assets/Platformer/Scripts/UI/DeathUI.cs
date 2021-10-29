using UnityEngine;

public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;

    public void OnDeath(MonoBehaviour _player)
    {
        deathUI.SetActive(true);
    }
}
