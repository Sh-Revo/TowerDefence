using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int moneyValue = 50;
    public GameObject deathEffect;

    private Transform _target;
    private int _wayPointIndex = 0;

    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.money += moneyValue;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }


    void GetNextWayPoint()
    {
        if (_wayPointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        _wayPointIndex++;
        _target = Waypoints.points[_wayPointIndex];
    }

    void EndPath()
    {

        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
