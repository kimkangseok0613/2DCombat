using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUser : SingleTon<InputUser>
{
    [HideInInspector]public Control control;

    [HideInInspector]public Vector2 moveInput;

    protected override void Awake()
    {
        control = new Control();

        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

   
    private void OnEnable()
    {
        control.Enable();

    }
    private void OnDisable()
    {
        control.Disable();
    }
    

    

}
