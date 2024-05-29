using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float _TimeLeft=60;

    private int _kills;

    [SerializeField] private TextMeshProUGUI _timer;

    [SerializeField] private TextMeshProUGUI _EnemiesDestroyed;

    public event Action GameLost;

    private bool gameLost = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }


    void Update()
    {
        if (gameLost == true) return;
        _timer.text = $"Time: {_TimeLeft-Time.time}";
        if (_TimeLeft - Time.time <= 0)
        {
            GameLost?.Invoke();

            gameLost = true;
        }
    
    }

    public void AddTimeAndKills(float time, int kill)
    {
        _TimeLeft += time;

        _kills += kill;

        _EnemiesDestroyed.text = $"Enemies killed: {_kills}";
    }
}
