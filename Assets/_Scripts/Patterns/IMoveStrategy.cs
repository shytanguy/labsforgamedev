using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
    public void Move(Rigidbody rigidbody, float speed, Transform target);
}
