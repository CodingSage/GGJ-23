using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class BossEnemyController : MonoBehaviour
{
    private Mover mover;
    private Attacker attacker;
    public Transform target;
    private float timer;
    private bool cooldown;
    private Animator animator;

    void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
        timer = 0f;
        cooldown = false;
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;

        animator.SetBool("Walk", true);
        // Move towards target and attack. If successful, cooldown starts, and enemy pulls back till cooldown ends
        if (!cooldown)
        {
            mover.MoveWithVelocity(direction);
            animator.SetBool("Fight", true);
            cooldown = attacker.Attack();
            if (cooldown)
            {
                animator.SetBool("Fight", false);
                Debug.Log("Enemy attacked, cooldown starts");
                timer = 0f;
            }
        }
        else 
        {
            animator.SetBool("Fight", false);
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
