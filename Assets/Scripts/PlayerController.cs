using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MyInputActions inputActions;
    public  Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        inputActions = new MyInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Gameplay.Use.performed += Use_performed;
        inputActions.Gameplay.Movement.performed += Movement_performed;
    }

    private void Use_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rb.velocity = speed * obj.ReadValue<Vector2>();
        if (obj.ReadValue<Vector2>().x != 0)
        {
            transform.localScale = new Vector3(obj.ReadValue<Vector2>().x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
