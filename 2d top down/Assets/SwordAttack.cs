using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

   public float damage = 1;
   public Collider2D swordCollider;
   private Vector2 _rightAttackOffset;

   private void Start()
   {
      _rightAttackOffset = transform.position;
   }
   
   public void attackRight()
   {
      print("attack right");

      swordCollider.enabled = true;
      transform.localPosition = _rightAttackOffset;
   }

   public void attackLeft()
   {
      print("attack left");
      swordCollider.enabled = true;
      transform.localPosition = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
   }

   public void stopAttack()
   {
      swordCollider.enabled = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      print("enter");
      if (other.tag == "Enemy")
      {
         Enemy enemy = other.GetComponent<Enemy>();
         if (enemy != null)
         {
            enemy.Health -= damage;
         }
         //deal damage to enemy;
      }
   }
}
