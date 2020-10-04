using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTester : MonoBehaviour
{
    private HealthBarController healthBar;

    void Awake()
    {
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            healthBar.changeHealth(1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            healthBar.changeHealth(-1);
        }
    }
}
