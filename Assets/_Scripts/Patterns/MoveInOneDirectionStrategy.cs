using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInOneDirectionStrategy : IMoveStrategy
{
    protected Vector3 _direction;
    public void Move(Transform transform, float speed, Transform target)
    {
        transform.Translate(speed * _direction);
        transform.forward = _direction;
    }
}
