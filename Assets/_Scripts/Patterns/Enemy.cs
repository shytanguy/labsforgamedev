using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObserver
{
    public static TargetFlyweight flyweight;

    public Color color;

    public IMoveStrategy strategy= new FollowStrategy();

    private Rigidbody _boxRigidBody;

    [SerializeField] private float TotalHp=100;
    private float _hp=100;
    [SerializeField] private GameObject brokenBox;
  [Serializable]  private enum StrategyType
    {
        follow,
        escape
    }

    [SerializeField] private StrategyType type;
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        _boxRigidBody = GetComponent<Rigidbody>();
        if (type == StrategyType.follow)
        {
            strategy = new FollowStrategy();
        }
        else
        {
            strategy = new EscapeStrategy();
        }
        _hp = TotalHp;
        EnemyBehaviourGlobal.instance.AddObserver(this);
       
    }
    private void FixedUpdate()
    {
        strategy.Move(_boxRigidBody, flyweight.Speed, flyweight.Target);
    }

    public void RemoveHp(float damage)
    {
        _hp -= TotalHp;

        if (_hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(brokenBox, transform.position, transform.rotation);
        }
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
