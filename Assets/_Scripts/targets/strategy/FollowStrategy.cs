using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowStrategy : IMoveStrategy
{
    public void Move(Rigidbody rigidbody, float speed, Transform target)
    {
        Vector3 direction = (target.position - rigidbody.transform.position).normalized;

        rigidbody.velocity = new Vector3(direction.x, 0, direction.z);

        rigidbody.transform.forward = direction;
    }
}
