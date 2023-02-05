using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private SpriteRenderer spriteRenderer;
    private Attacker attacker;
    private Attackable attackable;
    private Vector2 originalPosition;
    private Animator animator;

    void Start()
    {
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        attackable = GetComponent<Attackable>();
        originalPosition = gameObject.transform.position;
        animator = GetComponent<Animator>();
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
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mover.MoveWithVelocity(Vector2.right);
            spriteRenderer.flipX = false;
            animator.SetBool("Walk", true);
        }
        else
        {
            mover.StopMovement();
            animator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            attacker.Attack();
            StartCoroutine(AttackAnimation());
        }
    }

    IEnumerator AttackAnimation()
    {
        animator.SetBool("Fight", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("Fight", false);
    }

    public bool IsAlive()
    {
        return attackable.health > 0;
    }
}
