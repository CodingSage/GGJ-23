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
    private Vector2 originalPosition;

    void Start()
    {
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        attackable = GetComponent<Attackable>();
        originalPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 currentPosition = gameObject.transform.position;
            if(currentPosition.x > originalPosition.x)
            {
                mover.MoveWithVelocity(-Vector2.right);
                spriteRenderer.flipX = true;
            }
            else
            {
                mover.StopMovement();
            }
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
    }

    public bool IsAlive()
    {
        return attackable.health > 0;
    }
}
