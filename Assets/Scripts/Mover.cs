using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    public float accelaration = 5f;
    public float maxSpeed = 5f;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void MoveWithVelocity(Vector2 direction)
    {
        body.velocity = maxSpeed * Vector3.Normalize(direction);
    }

    public void AccelarateInDirection(Vector2 direction)
    {
        direction = Vector3.Normalize(direction);
        Vector2 newVelocity = body.velocity + direction * accelaration * Time.deltaTime;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -maxSpeed, maxSpeed);
        body.velocity = newVelocity;
    }

    public void StopMovement()
    {
        body.velocity = Vector2.zero;
    }
}
