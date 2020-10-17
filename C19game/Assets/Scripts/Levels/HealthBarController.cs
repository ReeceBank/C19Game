using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public int currentHealth = 30;
    public int maxHealth = 30;
    public SceneLoader endScene;

    [SerializeField]
    public Text value;

    /*
     * gets and sets healthbar
     */
    void Awake()
    {
        healthBar = GetComponent<Slider>();
        if(Difficulty.difficulty == 1)
        {
            currentHealth = 30;
        }
        if (Difficulty.difficulty == 2)
        {
            currentHealth = 30;
        }
        if (Difficulty.difficulty == 3)
        {
            currentHealth = 15;
            maxHealth = 15;
        }
    }
    
    /*
     * gets current health and maximum health values
     * display said values on the slider
     */
    void Update()
    {

        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
        value.text = currentHealth + " / " + maxHealth;
       
    }

    /*
     * gets current health value
     * based on value either sets value, increments value or ends the game
     */
    public void changeHealth(int dHP)
    {
        if(currentHealth + dHP > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth + dHP <= 0)
        {
            //end game
            currentHealth = 0;
            endScene.LoadEndGame();
            //current end game
        }
        else
        {
            currentHealth += dHP;
        }


    }

    /*
     * Sets maximum health
     */
    public void setMaxHealth(int maxHP)
    {
        maxHealth = maxHP;
    }
    /*
     * sets current health value
     */
    public void setCurrentHealth(int currentHP)
    {
        currentHealth = currentHP;
    }
}
