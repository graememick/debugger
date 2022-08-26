using Interfaces;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public HealthBar healthBar;
    public GameObject gameOverScreen;
    public EnemySpawner enemySpawner;
    public float Health
    {
        set
        {
            health = value;

            print(" value:" + value);
            print("health :" + value);
            
            if (health <= 0)
            {
                targetable = false;

                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public bool targetable;

    public bool Targetable
    {
        set
        {
            targetable = value;
            //_rigidbody.simulated = value;
        }
        get
        {
            return targetable;
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
            healthBar.SetHealth(health);
        } 
    }

    public float health = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(health);

    }

    private void Defeated()
    {
        _animator.SetTrigger("Defeated");

        if (gameObject.tag == "ComputerMain")
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            enemySpawner.SpawnNewSlime();

        }

    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");

    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
        gameOverScreen.SetActive(true);

        if (gameObject.tag == "Player")
        {
            print("player dead");
            gameOverScreen.SetActive(true);
            
        }
        
    }
}