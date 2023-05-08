using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public float health;
    public EnemyStats stats;
    
    void Start()
    {
        maxHealth = stats.maxHealth;
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void Heal(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
