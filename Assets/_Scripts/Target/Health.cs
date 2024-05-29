using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHp;

    private float _currentHp;

    [SerializeField] private AudioClip _destroySound;

    [SerializeField] private GameObject _effect;


    [SerializeField] private float _additionalDamage;

    [SerializeField] private float _additionalSpeed;

    [SerializeField] private float _time;
    private void Start()
    {
        _currentHp = _maxHp;
    }
    

    public float Damage(float damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            Instantiate(_effect, transform.position, transform.rotation);
            TargetBonusManager.instance.NotifyObservers(_additionalDamage, _additionalSpeed, _time);

            Destroy(gameObject);
       
        }

        return _currentHp;
    }
}
