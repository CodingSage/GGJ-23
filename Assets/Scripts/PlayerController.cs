using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private SpriteRenderer spriteRenderer;
    private Attacker attacker;
    private Attackable attackable;

    void Start()
    {
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        attackable = GetComponent<Attackable>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mover.MoveWithVelocity(-Vector2.right);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mover.MoveWithVelocity(Vector2.right);
            spriteRenderer.flipX = false;
        }
        else
        {
            mover.StopMovement();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            attacker.Attack();
        }

        if (attackable.health <= 0)
        {

        }
    }
}
