using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyQueen : Enemy
{
    private float _spawnCooldown;
    private float _currentSpawnCooldown;

    protected override void Start()
    {
        base.Start();
        EnemySetUp(4, 50, 20);
        _spawnCooldown = 1.5f;
        _currentSpawnCooldown = _spawnCooldown;
    }

    private void Update()
    {
        if (_currentSpawnCooldown > 0)
            _currentSpawnCooldown -= Time.deltaTime;
        if (_currentSpawnCooldown <= 0)
            SpawnFlies(10);
    }

    private void SpawnFlies(int count)
    {
        _currentSpawnCooldown = _spawnCooldown;
        for (int i = 0; i <= count; i++)
        {
            Vector3 pos = RandomCircle(transform.position, 2);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, transform.position - pos);
            Instantiate(GameObject.Find("Fly"), pos, rot);
        }
    }
    
    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
