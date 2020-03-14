using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : Enemy
{
    private void Awake()
    {
        EnemySetUp(9, 5, 10);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>() != null)
            Destroy(gameObject);
    }
}