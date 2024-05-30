using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    public static PointsCounter instance;

    private int points=0;
    private float time=60;

    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI pointsCounter;

    [SerializeField] private TextMeshProUGUI _prefab;

    [SerializeField] private Transform parent;

    private bool done=false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(instance);

        SavingScript.Load();
    }

    private void Update()
    {
        if (time- Time.time <= 0&&!done)
        {
            done = true;
            ShowRecords();
            Time.timeScale = 0;
        }
        timer.text = (time - Time.time).ToString("0,0");

    }

    public void AddTimeAndPoints(float time)
    {
        this.time += time;
        points += 1;
        pointsCounter.text = "destroyed: " + points;
    }

    public void ShowRecords()
    {
        parent.gameObject.SetActive(true);
        SavingScript.AddRecord(points);

        Instantiate(_prefab, parent).text="your points: "+points.ToString();

        foreach(int record in SavingScript.records)
        {

            Instantiate(_prefab, parent).text = "previous: " + points.ToString();
        }
     
        SavingScript.Save(points);
    }
}
