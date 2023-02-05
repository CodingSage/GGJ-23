using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attackable : MonoBehaviour
{

    public float fullHealth = 50f;
    public float health = 50f;
    public float defence = 10f;
    public Slider slider;

    void Start()
    {
    }

    void Update()
    {  
    }

    // Return true if health < 0, else return false
    public bool TakeDamage(float damage)
    {
        float damageAmount = damage* defence / 100;
        health -= damageAmount;
        Debug.Log("Took damage of " + damageAmount);
        if (health < 0)
        {
            return true;
        }
        return false;
    }

    public void DeadState()
    {
        // destroy object for now
        Debug.Log("Destroying attackable with health " + health);
        Destroy(gameObject);
        // gameObject.active = false;
    }

    public float HealthPercentage()
    {
        return health / fullHealth;
    }
}
