using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
   private Collider2D  _swordCollider;
   private Vector2 _rightAttackOffset;

   private void Start()
   {
      _swordCollider = GetComponent<Collider2D>();
      _rightAttackOffset = transform.position;
   }
   
   public void attackRight()
   {
      print("attack right");

      _swordCollider.enabled = true;
      transform.position = _rightAttackOffset;
   }

   public void attackLeft()
   {
      print("attack left");
      _swordCollider.enabled = true;
      transform.position = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
   }

   public void stopAttack()
   {
      _swordCollider.enabled = false;
   }
}
