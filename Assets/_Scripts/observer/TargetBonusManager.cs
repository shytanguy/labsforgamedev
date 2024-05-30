using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TargetBonusManager: MonoBehaviour, IObservable
{
    public static TargetBonusManager instance;

    private List<Health> _enemies=new List<Health>();

    private List<IObserver> _observers = new List<IObserver>();
    private void Awake()
    {
       
            instance = this;
 
    }
    public void AddObserver(IObserver iobserver)
    {
        _observers.Add(iobserver);
    }

    public void NotifyObservers(float damage, float speed, float time)
    {
        foreach(IObserver observer in _observers)
        {
            observer.Observe(damage, speed, time);
        }
    }

    public void RemoveObserver(IObserver iobserver)
    {
        _observers.Remove(iobserver);
    }


}
