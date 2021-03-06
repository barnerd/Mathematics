using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public SpriteRenderer image;
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        if (item.useSprite)
        {
            image.sprite = item.image;
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(false);
        }
        else
        {
            text.text = item.displayText;
            text.gameObject.SetActive(true);
            image.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if(item is CollectionItem)
            {
                collider.GetComponent<Character>().CollectCollectionItem(item);
            }

            // perform collection animation
            // perform collection sound

            item.CollectItem();

            Destroy(gameObject);
        }

        if (item is PowerUpItem)
        {
            collider.GetComponent<Character>().GainPowerUp(item);

            item.CollectItem();

            Destroy(gameObject);
        }
    }
}
