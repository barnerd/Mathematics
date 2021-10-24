using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public CharacterData data;

    private InputController currentController;
    public TextMeshPro text;

    public ItemSet operators;

    public List<PowerUpItem> powerUps;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplayText();

        currentController = data.controller;
        currentController.Initialize(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is used with physics
    void FixedUpdate()
    {
        currentController.ProcessInput(gameObject);
    }

    public void CollectCollectionItem(ScriptableObject _item)
    {
        operators.UpdateCollection(_item);
    }

    public void UpdateDisplayText()
    {
        string displayText = data.representation;

        foreach (PowerUpItem pu in powerUps)
        {
            displayText = pu.displayText.Substring(0, 1) + displayText + pu.displayText.Substring(pu.displayText.Length - 1);
        }

        text.text = displayText;
    }

    public void GainPowerUp(ScriptableObject _item)
    {
        PowerUpItem powerUP = (PowerUpItem)_item;

        powerUps.Add(powerUP);
        powerUps.Sort();

        UpdateDisplayText();

        if (powerUP.duration > 0)
        {
            StartCoroutine(RemovePowerUpRoutine(_item, powerUP.duration));
        }
    }

    private IEnumerator RemovePowerUpRoutine(ScriptableObject _item, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        RemovePowerUp(_item);
    }

    public void RemovePowerUp(ScriptableObject _item)
    {
        PowerUpItem powerUP = (PowerUpItem)_item;

        if (powerUps.Contains(powerUP))
        {
            powerUps.Remove(powerUP);
            UpdateDisplayText();
        }
        else
        {
            // This is an error and shouldn't happen.
            Debug.LogError("Tried to remove powerup that this character doesn't have: " + powerUP);
        }
    }
}
