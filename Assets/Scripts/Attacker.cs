using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Attacker : MonoBehaviour
{

    public float attack = 10f;
    private HashSet<Attackable> inRange;

    void Start()
    {
        inRange = new HashSet<Attackable>();
    }

    public bool Attack()
    {
        bool attacked = false;
        List<Attackable> removeFromRange = new List<Attackable>();
        foreach (Attackable attackable in inRange)
        {
            Debug.Log("Dealing damage " + attack);
            if(attackable.TakeDamage(attack))
            {
                removeFromRange.Add(attackable);
            }
        }

        foreach (Attackable attackable in removeFromRange)
        {
            inRange.Remove(attackable);
            attackable.DeadState();
        }

        return attacked;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attackable attackable = collision.GetComponent<Attackable>();
        if (attackable != null)
        {
            Debug.Log("Adding collider to inRange");
            inRange.Add(attackable);
            Debug.Log("Count in range " + inRange.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Attackable attackable = collision.GetComponent<Attackable>();
        if (attackable != null)
        {
            Debug.Log("Removing collider from inRange");
            inRange.Remove(attackable);
            Debug.Log("Count in range " + inRange.Count);
        }
    }
}
