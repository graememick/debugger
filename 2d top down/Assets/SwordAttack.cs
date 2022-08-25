
using Interfaces;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

   public float damage = 1;
   public float blowbackForce = 1f;
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

   private void OnTriggerEnter2D(Collider2D collider)
   {

      IDamageable damageableObject = collider.GetComponent<IDamageable>();

      if (damageableObject != null)
      {
         Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

         Vector2 direction = (Vector2)(collider.gameObject.transform.position - parentPosition).normalized;
         Vector2 knockback = direction * blowbackForce;
         
         //collider.SendMessage("onHit", damage, knockback);
         damageableObject.OnHit(damage, knockback);

      }
      else
      {
         Debug.LogWarning("Collider does not implement IDamagable");
      }
      
   }
}
