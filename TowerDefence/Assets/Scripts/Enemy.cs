﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float _health;
    public int moneyValue = 50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool _isDead = false;

    private void Start()
    {
        speed = startSpeed;
        _health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        healthBar.fillAmount = _health / startHealth;
        if (_health <= 0 && !_isDead)
        {
            Die();
        }
    }

    void Die()
    {
        _isDead = true;
        PlayerStats.money += moneyValue;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
