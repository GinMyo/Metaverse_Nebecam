using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private new Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
    
    void OnLook(InputValue inputValue)
    {
        // 마우스의 좌표는 해상도의 좌표
        Vector2 mousePosition = inputValue.Get<Vector2>();
        // 해상도의 좌표를 world 좌표로 바꿔주는 작업
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
