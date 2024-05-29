using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour, IObserver
{

    public static TargetFlyweight flyweight;
    [SerializeField] private float TotalHp=10;

    private float currentHp;

    private IMoveStrategy moveStrategy;

   [SerializeField] private bool type;

    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private float _speed;

    [SerializeField] private float addTime = 5;

    [SerializeField] private bool destroyAll=false;

    [SerializeField] private AudioClip _shot;

    [SerializeField] private AudioSource source;

    [SerializeField] private GameObject _effect;
    void Start()
    {
        switch (type)
        {
            case false: moveStrategy = new FollowStrategy();
                break;
            case true: moveStrategy = new EscapeStrategy();
                break;
        }
        source = GetComponent<AudioSource>();
        GameManager.instance.AddObserver(this);
    }

    
    void FixedUpdate()
    {
        moveStrategy.Move(rigidbody, _speed, flyweight.Target);
    }

    public void RecieveDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            GameManager.instance.AddTimeAndKills(addTime, 1);
            GameManager.instance.RemoveObserver(this);
            if (destroyAll)
                GameManager.instance.NotifyObservers();
            source.PlayOneShot(_shot);
            Instantiate(_effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Observe()
    {
        if (destroyAll) return;
        GameManager.instance.AddTimeAndKills(addTime, 1);
        GameManager.instance.RemoveObserver(this);
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
