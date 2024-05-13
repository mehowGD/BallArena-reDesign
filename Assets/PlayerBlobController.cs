
using System;
using Assets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlobController : MonoBehaviour
{
    public SteerGuide Guide;
    public float AttractionCoefficient;
    public float Drag;
    
    Vector2 mSpeed;

    void Start()
    {
        TimeManager.Instance.TimeUpdate += OnUpdate;
    }

    void Update ()
    {
        //OnUpdate(Time.deltaTime);
    }

    void OnUpdate(float time)
    {
        mSpeed += (Guide.transform.position - transform.position).ToVector2() * AttractionCoefficient * time;
        mSpeed *= 1f - Drag * time;
        
        transform.position += mSpeed.ToVector3() * time;
    }
}
