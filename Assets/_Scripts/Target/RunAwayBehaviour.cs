using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayBehaviour : IMoveStrategy
{
    public void Move(Transform transform, float speed, Transform target)
    {
        Vector3 direction = (transform.position -target.position).normalized;

        transform.Translate(speed * new Vector3(direction.x, 0, direction.z));

        transform.forward = -direction;
    }
}