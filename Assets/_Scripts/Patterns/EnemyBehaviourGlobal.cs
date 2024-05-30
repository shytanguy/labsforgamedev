using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyBehaviourGlobal: MonoBehaviour, IObservable
{
    [SerializeField] private static float _timeBetweenChange=10;

    private static List<IObserver> observers = new List<IObserver>();

    public static EnemyBehaviourGlobal instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    public  void AddObserver(IObserver iobserver)
    {
        observers.Add(iobserver);
    }

    public void NotifyObservers()
    {
        foreach(var observer in observers)
        {
            observer.Observe();
        }
    }

    public void RemoveObserver(IObserver iobserver)
    {
        observers.Remove(iobserver);
    }
}
