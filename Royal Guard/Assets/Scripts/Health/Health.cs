using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int maximumHealth = 10;

    private int currentHealth = 0;

    [SerializeField]
    private HealthDisplay healthDisplay;

    public void Reduce(int ammount)
    {
        currentHealth -= ammount;

        currentHealth = currentHealth < 0 ? 0 : currentHealth;

        ChangeHealthDisplay();
        LogDeath();
    }  

    void Start () {
        currentHealth = maximumHealth;

        ChangeHealthDisplay();
    }

    private void ChangeHealthDisplay()
    {
        healthDisplay.Set(currentHealth);
    }

    private void LogDeath()
    {
        if (currentHealth <= 0)
            Debug.Log("Character is dead.");
    }

    private void Initialize()
    {
        currentHealth = maximumHealth;
    }
    

}
