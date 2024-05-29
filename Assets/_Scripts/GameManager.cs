using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{
    public static GameManager instance;

    private bool _GameEnded = false;

    private float _GameTime = 30;
    public event Action<float> GameLost;

    [SerializeField] private TextMeshProUGUI _Timer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

    }
    private void Start()
    {
        TargetBonusManager.instance.AddObserver(this);
    }

    private void FixedUpdate()
    {
       

        if (_GameTime - Time.time <= 0&&_GameEnded==false)
        {
            _GameEnded = true;
            Debug.Log("lost");
            GameLost?.Invoke(Time.time);
        }
        else
            _Timer.text = $"Time Remaining: {(_GameTime - Time.time).ToString("0.00")}";
    }

    public void Observe(float damage, float speed, float time)
    {
        _GameTime += time;
    }
}
