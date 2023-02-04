using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

    public float health;
    public float defence;

    void Start()
    {
        health = 50f;
        defence = 10f;
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
}
