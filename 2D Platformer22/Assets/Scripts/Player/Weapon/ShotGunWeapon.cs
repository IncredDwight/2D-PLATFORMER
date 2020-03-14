using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunWeapon : Weapon
{
    private void Start()
    {
        WeaponSetUp(2f, 10, FindObjectOfType<ShotGunProjectile>().gameObject);
    }
}
