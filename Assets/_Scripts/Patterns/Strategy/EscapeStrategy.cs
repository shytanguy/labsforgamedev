using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeStrategy : IMoveStrategy
{
    public void Move(Rigidbody rigidbody, float speed, Transform target)
    {
        Vector3 direction = -(target.position - rigidbody.transform.position).normalized;
        rigidbody.velocity = direction * speed;

        rigidbody.transform.forward = rigidbody.velocity;
    }
}