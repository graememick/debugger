using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f; 
    
    Vector2 _movementInput;
    private Rigidbody2D _rigidBody;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame updateß
    void Start()
    {

        _rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Update 100 x per second
    private void FixedUpdate()
    {
        //if movement is not zero, move
        if (_movementInput != Vector2.zero)
        {
            int count= _rigidBody.Cast(
                _movementInput,
                movementFilter,
                castCollisions,
                moveSpeed*Time.fixedDeltaTime+collisionOffset
            );
            if (count == 0)
            {
                _rigidBody.MovePosition(_rigidBody.position + _movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }
}
