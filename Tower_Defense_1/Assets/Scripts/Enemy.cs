using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float Health = 100;
    public int worth = 100;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Slow(float slowPerc)
    {
        speed = startSpeed * (1f - slowPerc);
    }
    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2);
        Destroy(gameObject);
    }

    
}
