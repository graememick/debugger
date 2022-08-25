using System;
using Interfaces;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public float damage = 1;
    public float Health

    {
        set
        {
            health = value;

            print(" value:" + value);
            print("health :" + value);
            
            if (health <= 0)
            {
                _targetable = false;

                Defeated();
            }

           

            
        }
        get
        {
            return health;
        }
    }

    public bool _targetable;

    public bool Targetable
    {
        set
        {
            _targetable = value;
            //_rigidbody.simulated = value;
        }
        get
        {
            return _targetable;
        }
    }
    public void OnHit(float damage)
    {
        Health -= damage;
        if (health > 0)
        {
            Hit();
        } 
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        _rigidbody.AddForce(knockback, ForceMode2D.Impulse);
        if (health > 0)
        {
            Hit();
        } 
    }

    public float health = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Defeated()
    {
    _animator.SetTrigger("Defeated");
        
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");

    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collided");
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
