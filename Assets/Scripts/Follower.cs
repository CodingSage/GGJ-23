using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 followerPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        transform.position = followerPosition;
    }
}
