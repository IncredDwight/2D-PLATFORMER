using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeSystem : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeapon;

    private void Start()
    {
        weapons[0] = FindObjectOfType<DefaultWeapon>().gameObject;
        weapons[1] = FindObjectOfType<ShotGunWeapon>().gameObject;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentWeapon = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            currentWeapon = 1;
        if (currentWeapon == 0)
        {
            weapons[0].SetActive(true);
            weapons[1].transform.position = new Vector3(0, 0, -10);
            weapons[1].SetActive(false);
        }
        else if (currentWeapon == 1)
        {
            weapons[1].SetActive(true);
            weapons[0].transform.position = new Vector3(0, 0, -10);
            weapons[0].SetActive(false);
        }
    }
}
