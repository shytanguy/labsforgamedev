using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    public void Observe(float damage, float speed, float time);
}
