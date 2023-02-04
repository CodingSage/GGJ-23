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

    public void TakeDamage(float damage)
    {
        float damageAmount = damage* defence / 100;
        health -= damageAmount;
        Debug.Log("Took damage of " + damageAmount);
        if (health < 0)
        {
            DeadState();
        }
    }

    private void DeadState()
    {
        // remove sprite for now
        this.enabled = false;
    }
}
