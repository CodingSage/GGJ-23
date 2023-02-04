using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

    public float health = 50f;
    public float defence = 10f;

    void Start()
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
}
