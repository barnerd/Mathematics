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

    public GameEvent onPlayerDeath;

    public int currentHitPoints;

    public float vultnerabilityDuration;
    private float nextTimeForCollision;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeForCollision = Time.time;

        UpdateDisplayText();

        currentHitPoints = data.maxHitPoints;

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

    public void Heal(int hitsHealed)
    {
        currentHitPoints += hitsHealed;

        if (currentHitPoints > data.maxHitPoints)
        {
            currentHitPoints = data.maxHitPoints;
        }
    }

    public void TakeHit(int damage = 1)
    {
        PowerUpItem powerUp = null;
        string powerUpName = "";

        if (powerUps.Count > 0)
        {
            powerUp = powerUps[powerUps.Count - 1];
            powerUpName = powerUp.name;
        }

        switch (powerUpName)
        {
            case "BasicShields":
                RemovePowerUp(powerUp);
                break;
            case "PushShields":

                break;
            case "GunShields":

                break;
            default:
                currentHitPoints -= damage;
                break;
        }

        if (currentHitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (onPlayerDeath != null)
        {
            // TODO: player death animation
            onPlayerDeath.Raise(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time > nextTimeForCollision)
        {
            nextTimeForCollision = Time.time + vultnerabilityDuration;

            if (collision.otherCollider.tag == "Player" && collision.collider.tag == "Enemy")
            {
                Character enemy = collision.collider.GetComponent<Character>();

                TakeHit(enemy.data.damage);
            }

            if (collision.otherCollider.tag == "Enemy" && collision.collider.tag == "Enemy")
            {
                GetComponent<CharacterMotor>().Flip();
            }
        }
    }
}
