using System;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    public int TargetFramerate => 60;
    public event Action<float> TimeUpdate;
    public event Action<float> LateTimeUpdate;

    float mLastUpdate;
    
    void Awake()
    {
        mLastUpdate = Time.time;

        Instance = this;

        Application.targetFrameRate = TargetFramerate;
    }

    void Update()
    {
        while (Time.time - mLastUpdate > 1f / TargetFramerate)
        {
            TimeUpdate?.Invoke(1f / TargetFramerate);
            LateTimeUpdate?.Invoke(1f / TargetFramerate);

            mLastUpdate += 1f / TargetFramerate;
        }
    }
}
