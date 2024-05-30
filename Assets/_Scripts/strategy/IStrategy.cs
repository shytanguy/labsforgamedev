using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
    public void Move(Transform transform, float speed, Transform target);
}
