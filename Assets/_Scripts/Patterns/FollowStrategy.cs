using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowStrategy : IMoveStrategy
{
    public void Move(Transform transform, float speed, Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;

        transform.Translate(speed *new Vector3(direction.x,0,direction.z));

        transform.forward = direction;
    }
}
