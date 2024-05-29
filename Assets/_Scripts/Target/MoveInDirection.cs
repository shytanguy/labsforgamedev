using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : IMoveStrategy
{
    protected Vector3 _direction;
    public void Move(Transform transform, float speed, Transform target)
    {
        transform.Translate(speed * _direction);
    }
}
