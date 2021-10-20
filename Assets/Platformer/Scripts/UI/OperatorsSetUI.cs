using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperatorsSetUI : MonoBehaviour
{
    public ItemSet operators;
    public TextMeshProUGUI[] setItemsText;

    public Color nonCollectedColor;
    public Color collectedColor;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCollectionText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCollectionText()
    {
        for (int i = 0; i < operators.itemsInSet.Length; i++)
        {
            setItemsText[i].color = operators.collected[i] ? collectedColor : nonCollectedColor;
        }
    }
}
