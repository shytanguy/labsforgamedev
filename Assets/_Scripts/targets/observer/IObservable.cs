using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable {

    public void AddObserver(IObserver iobserver);

    public void RemoveObserver(IObserver iobserver);

    public void NotifyObservers();
}
