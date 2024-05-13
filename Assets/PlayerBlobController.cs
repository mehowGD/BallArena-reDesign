
using System;
using Assets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlobController : MonoBehaviour
{
    public float Drag;

    Vector2 mMovement;
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
        mSpeed += mMovement * time;
        mSpeed *= 1f - Drag * time;
        
        transform.position += mSpeed.ToVector3() * time;
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        mMovement = context.ReadValue<Vector2>();
    }
}
