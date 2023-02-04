using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
public class BossEnemyController : MonoBehaviour
{
    private Mover mover;
    private Attacker attacker;
    public Transform target;
    private float timer;
    private bool cooldown;

    void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        timer = 0f;
        cooldown = false;
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;

        // Move towards target and attack. If successful, cooldown starts, and enemy pulls back till cooldown ends
        if (!cooldown)
        {
            mover.MoveWithVelocity(direction);
            cooldown = attacker.Attack();
            if (cooldown)
            {
                Debug.Log("Enemy attacked, cooldown starts");
                timer = 0f;
            }
        }
        else 
        {
            direction = new Vector2(direction.x, -direction.y);
            mover.MoveWithVelocity(direction);
            timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds > 2)
            {
                Debug.Log("Cooldown stops");
                cooldown = false;
            }
        }
    }
}
