using System;
using Cinemachine;
using Interfaces;
using UnityEngine;

public class Computer : MonoBehaviour
{

    public float damage = 0;
    public float blowbackForce = 1f;
    private Rigidbody2D rb;
    public Collider2D targetToDestroy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collided");
        Collider2D collider = col.collider;
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (collider.gameObject.transform.position - transform.position).normalized;
            Vector2 knockback = direction * blowbackForce;
         
            //collider.SendMessage("onHit", damage, knockback);
            damageable.OnHit(damage, knockback);
        }
        
    }
}

