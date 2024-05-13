using System;
using Assets;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public float FollowTime;
    
    Vector2 mVelocity;
    float mBaseDepth;

    void Start ()
    {
        mBaseDepth = transform.position.z;
        TimeManager.Instance.LateTimeUpdate += OnUpdate;
    }

    void LateUpdate ()
    {
        //OnUpdate(Time.deltaTime);
    }

    void OnUpdate(float time)
    {
        transform.position = Vector2.SmoothDamp(transform.position.ToVector2(), Player.transform.position.ToVector2(), ref mVelocity, FollowTime, Mathf.Infinity, time).ToVector3(mBaseDepth);
    }
}
