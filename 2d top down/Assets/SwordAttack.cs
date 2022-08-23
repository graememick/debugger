using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

   public float damage = 3;
   public Collider2D _swordCollider;
   private Vector2 _rightAttackOffset;

   private void Start()
   {
      _rightAttackOffset = transform.position;
   }
   
   public void attackRight()
   {
      print("attack right");

      _swordCollider.enabled = true;
      transform.localPosition = _rightAttackOffset;
   }

   public void attackLeft()
   {
      print("attack left");
      _swordCollider.enabled = true;
      transform.localPosition = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
   }

   public void stopAttack()
   {
      _swordCollider.enabled = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Enemy")
      {
         Enemy enemy = other.GetComponent<Enemy>();
         enemy.health -= damage;
         //deal damage to enemy;
      }
   }
}
