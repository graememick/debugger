using System;
using Cinemachine;
using Interfaces;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float damage = 1;
    public float blowbackForce = 1f;
    public DetectionZone detectionZone;
    public float moveSpeed = 50f;
    private Rigidbody2D rb;
    public Collider2D targetToDestroy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
        else if (detectionZone.detectedObjs.Count == 0)
        {
            Vector2 direction = (targetToDestroy.gameObject.transform.position - transform.position).normalized;
            
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
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
