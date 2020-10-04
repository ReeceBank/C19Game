using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public int currentHealth = 100;
    public int maxHealth = 100;

    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }
    void Update()
    {
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }
    public void changeHealth(int dHP)
    {
        currentHealth += dHP;
    }
    public void setMaxHealth(int maxHP)
    {
        maxHealth = maxHP;
    }
    public void setCurrentHealth(int currentHP)
    {
        currentHealth = currentHP;
    }
}
