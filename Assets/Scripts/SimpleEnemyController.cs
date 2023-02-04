using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
public class SimpleEnemyController : MonoBehaviour
{
    private Mover mover;
    private Attacker attacker;
    public Transform target;
    private float timer;
    
    void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        timer = 0f;
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        mover.MoveWithVelocity(direction);

        timer += Time.deltaTime;
        float seconds = timer % 60;
        if (seconds > 3)
        {
            // attack once every 3 seconds
            attacker.Attack();
            timer = 0f;
        }
    }
}
