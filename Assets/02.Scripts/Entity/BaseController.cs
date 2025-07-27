using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirectoin { get { return lookDirection; } }

    protected AnimaitionHandler animaitionHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animaitionHandler = GetComponent<AnimaitionHandler>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
        animaitionHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
}

