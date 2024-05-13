using Assets;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteerGuide : MonoBehaviour
{
    public Camera Camera;

    Vector2 mPosition;

    void Start()
    {
        TimeManager.Instance.TimeUpdate += OnUpdate;
    }

    void OnUpdate(float time)
    {
        transform.position = Camera.ScreenToWorldPoint(mPosition).ToVector2().ToVector3();
    }

    public void HandlePosition(InputAction.CallbackContext context)
    {
        mPosition = context.ReadValue<Vector2>(); 
    }
}
