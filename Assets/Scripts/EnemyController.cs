using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour
{
    private Attacker attacker;
    private SpriteRenderer spriteRenderer;
    private Mover mover;
    private EnemyBehaviour enemyBehaviour;

    void Start()
    {
        attacker = GetComponent<Attacker>();
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    void Update()
    {
        enemyBehaviour.Act();
    }
}
