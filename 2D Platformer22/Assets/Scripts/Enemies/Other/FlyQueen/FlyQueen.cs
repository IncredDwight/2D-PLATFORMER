using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyQueen : Enemy
{
    private float _spawnCooldown;
    private float _currentSpawnCooldown;
    GameObject fly;

    protected override void Start()
    {
        base.Start();
        fly = GameObject.Find("Fly");
        EnemySetUp(4, 50, 20);
        _spawnCooldown = 1.5f;
        _currentSpawnCooldown = _spawnCooldown;
    }

    private void Update()
    {
        if (_currentSpawnCooldown > 0)
            _currentSpawnCooldown -= Time.deltaTime;
        if (_currentSpawnCooldown <= 0)
            SpawnFly();
    }

    private void SpawnFly()
    {
        Instantiate(fly, transform.position - new Vector3(0, 1),Quaternion.identity);
        _currentSpawnCooldown = _spawnCooldown;
    }
    
}
