using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour, IObservable
{
    public static GameManager instance;

    private float _TimeLeft=30;

    private int _kills;

    [SerializeField] private TextMeshProUGUI _timer;

    [SerializeField] private TextMeshProUGUI _EnemiesDestroyed;

    public event Action GameLost;

    private bool gameLost = false;

    [SerializeField] private Transform _records;

    [SerializeField] private TextMeshProUGUI _recordPrefab;

    [SerializeField] private Transform[] _spawns;

    [SerializeField] private GameObject[] enemiesPrefabs;

    [SerializeField] private List<IObserver> enemies=new List<IObserver>();

    private float _spawnTimer;

    private float _spawnTime=5;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        Records.Load();

        GameLost += ShowResults;
    }


    void Update()
    {
        if (gameLost == true) return;

        if (Time.time - _spawnTimer >= _spawnTime)
        {
            _spawnTimer = Time.time;
            Instantiate(enemiesPrefabs[UnityEngine.Random.Range(0, enemiesPrefabs.Length)], _spawns[UnityEngine.Random.Range(0, _spawns.Length)].position, Quaternion.identity);
        }
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

    public void AddObserver(IObserver iobserver)
    {
        enemies.Add(iobserver);
    }

    public void RemoveObserver(IObserver iobserver)
    {
        enemies.Remove(iobserver);
    }

    public void NotifyObservers()
    {
       foreach(var enemy in enemies)
        {
            enemy.Observe();
        }
    }

    private void ShowResults()
    {
        _records.gameObject.SetActive(true);
        Records.records.Sort();
        Instantiate(_recordPrefab, _records).text = "your score: " + _kills.ToString();

        foreach(var i in Records.records)
        {
            Instantiate(_recordPrefab, _records).text = "your previous score: " + i.ToString();
        }

        Records.Save(_kills);
    }
}
