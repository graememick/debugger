using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    public float Health
    {
        set
        {
            print(" value:" + value);
            print("health :" + value);
            
            if (value < health && value > 0)
            {
                Hit();
            } else if (health <= 0)
            {
                Defeated();
            }

            health = value;
           

            
        }
        get
        {
            return health;
        }
    }

    public float health = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
}
