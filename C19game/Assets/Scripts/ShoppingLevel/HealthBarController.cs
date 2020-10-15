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

    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }
    void Update()
    {

        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
        value.text = currentHealth + " / " + maxHealth;
       
    }
    public void changeHealth(int dHP)
    {
        if(currentHealth + dHP > 30)
        {
            currentHealth = 30;
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
    public void setMaxHealth(int maxHP)
    {
        maxHealth = maxHP;
    }
    public void setCurrentHealth(int currentHP)
    {
        currentHealth = currentHP;
    }
}
