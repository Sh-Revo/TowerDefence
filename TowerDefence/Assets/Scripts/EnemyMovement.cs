using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wayPointIndex = 0;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        _enemy.speed = _enemy.startSpeed;
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
