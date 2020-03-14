using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedPistolEnemy : EnemyPathFinder
{
    private GameObject _projectile;

    private float _fireRate = 0.25f;
    private float _nextFire;

    private void Awake()
    {
        EnemySetUp(3, 20, 30);
    }

    protected override void Start()
    {
        base.Start();
        _projectile = FindObjectOfType<CursedWeaponProjectile>().gameObject;
    }

    private void Update()
    {
        transform.right = FindObjectOfType<PlayerStats>().transform.position - transform.position;
        transform.GetChild(0).rotation = transform.rotation;
        RaycastHit2D hit = Physics2D.Raycast(transform.GetChild(0).position, transform.right);
        if(hit.collider.GetComponent<PlayerStats>() != null)
            Shoot();
    }

    private void Shoot()
    {
        if(Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_projectile, transform.GetChild(0).transform.position, transform.rotation);
        }
    }
}
