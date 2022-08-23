using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public float collisionOffset = 0.05f; 
    
    Vector2 _movementInput;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private bool canMove = true;

    // Start is called before the first frame updateß
    void Start()
    {

        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Update 100 x per second
    private void FixedUpdate()
    {
        if (canMove)
        {
            //if movement is not zero, move
            if (_movementInput != Vector2.zero)
            {
                bool couldMove = tryMove(_movementInput);

                if (!couldMove && _movementInput.x > 0)
                {
                    couldMove = tryMove(new Vector2(_movementInput.x, 0));
                }

                if (!couldMove && _movementInput.y > 0)
                {
                    couldMove = tryMove(new Vector2(0, _movementInput.y));
                }

                _animator.SetBool("isMoving", couldMove);
            }
            else
            {
                _animator.SetBool("isMoving", false);
            }

            //set direction of sprite to movement direction
            if (_movementInput.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_movementInput.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

    private bool tryMove(Vector2 direction)
    {
        int count= _rigidBody.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed*Time.fixedDeltaTime+collisionOffset
        );
        if (count == 0)
        {
            _rigidBody.MovePosition(_rigidBody.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
    _animator.SetTrigger("swordAttack");

    }

    public void SwordAttack()
    {
        LockMove();    
    }

    public void EndSwordAttack()
    {
        UnlockMove();
        swordAttack.stopAttack();
    }
    
    void LockMove()
    {
        canMove = false;
        if (_spriteRenderer.flipX == true)
        {
            swordAttack.attackLeft();
        }
        else
        {
            swordAttack.attackRight();

        }
    }

    void UnlockMove()
    {
        canMove = true;
    }
}
