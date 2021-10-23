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

    // Start is called before the first frame update
    void Start()
    {
        text.text = data.representation;
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

    public void GainPowerUp(ScriptableObject _item)
    {
        Debug.Log(this.name + " has powered up with a " + ((PowerUpItem)_item).displayText);
    }
}
