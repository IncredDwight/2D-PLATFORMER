using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject _projectile;
    private Vector3 _difference;
    private Vector3 _weaponPos;
    private Vector3 _mouseInput;
    private PlayerStats _playerController;

    private float _fireRate;
    private float _nextFire;
    private int _ammo;
    private Vector3 _currentScale;

    private float rotZ;

    private void Awake()
    {
        _currentScale = transform.localScale;
        _playerController = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        Shoot();
        FollowCursor();
        WeaponFlip();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _ammo > 0)
        {
            if (Time.time > _nextFire)
            {
                Instantiate(_projectile, transform.GetChild(0).position, transform.rotation);
                _ammo--;
                _nextFire = Time.time + _fireRate;
            }
        }
    }

    private void FollowCursor()
    {
        _mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _weaponPos = _playerController.transform.position;
        transform.position = new Vector3(_weaponPos.x, _weaponPos.y, _weaponPos.z - 1);
        _difference = _mouseInput - transform.position;
        rotZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void WeaponFlip()
    {
        if (_mouseInput.x > _playerController.transform.position.x)
            transform.localScale = new Vector3(transform.localScale.x, _currentScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x, -_currentScale.y, transform.localScale.z);
    }

    protected void WeaponSetUp(float fireRate1, int ammo1, GameObject projectile1)
    {
        _fireRate = fireRate1;
        _ammo = ammo1;
        _projectile = projectile1;
    }
}
