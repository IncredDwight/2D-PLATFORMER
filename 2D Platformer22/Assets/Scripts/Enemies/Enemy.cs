using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float _movementSpeed;
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _health;
    protected float _maxHealth;

    private float _startScaleX;

    protected virtual void Start()
    {
        Debug.Log("Hi");
        _health = _maxHealth;
        _startScaleX = transform.localScale.x;
    }

    private void Update()
    {
        if (FindObjectOfType<PlayerStats>().transform.position.x < transform.position.x)
            transform.localScale = new Vector2(-_startScaleX, transform.localScale.y);
        else
            transform.localScale = new Vector2(_startScaleX, transform.localScale.y);
    }

    public void Heal(float heal)
    {
        _health += heal;
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Враг должен умирать, но программисту тоже кушац хочется(((");
        Destroy(gameObject);
    }

    protected void EnemySetUp(float movementSpeed1, float maxHealth1, float damage1)
    {
        _movementSpeed = movementSpeed1;
        _maxHealth = maxHealth1;
        _damage = damage1;
    }

}
