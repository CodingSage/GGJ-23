using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyBehaviour : EnemyBehaviour
{
    private Mover mover;
    private Attacker attacker;

    public StaticEnemyBehaviour(Mover mover, Attacker attacker)
    {
        this.mover = mover;
        this.attacker = attacker;
    }

    void EnemyBehaviour.Act()
    {
        
    }
}
