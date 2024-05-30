using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static TargetFlyweight flyweight;

    public Color color;

    public IMoveStrategy strategy= new FollowStrategy();

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

        if (type == StrategyType.follow)
        {
            strategy = new FollowStrategy();
        }
        else
        {
            strategy = new EscapeStrategy();
        }
        _hp = TotalHp;
    }
    private void FixedUpdate()
    {
        strategy.Move(transform, flyweight.Speed, flyweight.Target);
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
}
