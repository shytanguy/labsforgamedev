using System;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private IMoveStrategy _moveStrategy;
   public static TargetFlyweight flyweight;

    [Serializable]
    private enum Strategy
    {
        Follow,
        Direction,
        RunAway
    }

    [SerializeField] private Strategy _strategy;

    private void Start()
    {
      
        SetMoveStrategy();
    }

    private void FixedUpdate()
    {
        _moveStrategy.Move(transform, flyweight.Speed, flyweight.Target);
    }

    private void SetMoveStrategy()
    {
        switch (_strategy)
        {
            case Strategy.Follow:
                _moveStrategy = new FollowPlayer();
                break;
            case Strategy.Direction:
                _moveStrategy = new MoveInDirection();
                break;
            case Strategy.RunAway:
                _moveStrategy = new RunAwayBehaviour();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}