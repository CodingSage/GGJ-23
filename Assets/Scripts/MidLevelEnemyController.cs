using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
public class MidLevelEnemyController : MonoBehaviour
{
    public Transform target;
    public float movementLimitRange;

    private Mover mover;
    private Attacker attacker;
    private Vector3 originalPosition;
    private float attackTimer;
    private float randomMovementTimer;
    private bool directionModifier;

    void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        originalPosition = transform.position;
        attackTimer = 0f;
        randomMovementTimer = 0f;
        directionModifier = false;
    }

    void Update()
    {
        // randomize movement
        randomMovementTimer += Time.deltaTime;
        float movementSeconds = randomMovementTimer % 60;
        Vector2 direction = target.position - transform.position;
        if (directionModifier)
            direction = new Vector2(-direction.x, direction.y);
        if (movementSeconds > 1)
        {
            float roll = Random.Range(1f, 10f);
            if (roll > 5f) {
                // flip x
                directionModifier = !directionModifier;
                Debug.Log("Flipping enemy direction");
            }
            randomMovementTimer = 0f;
        }

        // move back towards original position if out of range limits
        Vector2 displacement = transform.position - originalPosition;
        if (displacement.magnitude > movementLimitRange)
        {
            direction = target.position - transform.position;
        }

        mover.MoveWithVelocity(direction);

        attackTimer += Time.deltaTime;
        float seconds = attackTimer % 60;
        if (seconds > 3)
        {
            // attack once every 3 seconds
            attacker.Attack();
            attackTimer = 0f;
        }
    }
}
