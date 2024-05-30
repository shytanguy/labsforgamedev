using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObserver
{
    public static TargetFlyweight flyweight;


    public IMoveStrategy strategy= new FollowStrategy();

    private Rigidbody _boxRigidBody;


    [SerializeField] private GameObject brokenBox;

    [SerializeField] private GameObject _effect;

    [SerializeField] private AudioClip _clip;

    [SerializeField] private AudioSource source;

    [SerializeField] private bool destroyAll=false;

    [SerializeField] private float giveTime = 10f;
  [Serializable]  private enum StrategyType
    {
        follow,
        escape
    }

    [SerializeField] private StrategyType type;
    private void Start()
    {
        _boxRigidBody = GetComponent<Rigidbody>();
        if (type == StrategyType.follow)
        {
            strategy = new FollowStrategy();
        }
        else
        {
            strategy = new EscapeStrategy();
        }

        EnemyBehaviourGlobal.instance.AddObserver(this);
        EnemyBehaviourGlobal.instance.AddBox(gameObject);
       
    }
    private void FixedUpdate()
    {
        strategy.Move(_boxRigidBody, flyweight.Speed, flyweight.Target);
    }

    public void DestroyBox()
    {
        EnemyBehaviourGlobal.instance.RemoveBox(gameObject);
        Destroy(gameObject);
        PointsCounter.instance.AddTimeAndPoints(giveTime);
        if (destroyAll)
        {
            EnemyBehaviourGlobal.instance.DestroyAll();
        }
            source.PlayOneShot(_clip);
            Instantiate(brokenBox, transform.position, transform.rotation);
            Instantiate(_effect, transform.position, transform.rotation);
     
        
    }

    public void Observe()
    {
        
        if (type == StrategyType.follow)
        {
            type = StrategyType.escape;
            strategy = new EscapeStrategy();
         
        }
        else
        {
            type = StrategyType.follow;
            strategy = new FollowStrategy();
        }
    }
}
