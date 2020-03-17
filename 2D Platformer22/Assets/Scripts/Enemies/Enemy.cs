using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    protected PlayerStats _playerStats;
    [SerializeField]
    protected float _movementSpeed;
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _health;
    protected float _maxHealth;

    private Vector3 _startScale;
    protected bool _flipY;

    protected virtual void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _health = _maxHealth;
        _startScale = transform.localScale;
    }

    protected virtual void Update()
    {
        if (FindObjectOfType<PlayerStats>().transform.position.x < transform.position.x)
            transform.localScale = (!_flipY) ? new Vector2(-_startScale.x, _startScale.y) : new Vector2(_startScale.x, -_startScale.y);
        else
            transform.localScale = new Vector2(_startScale.x, _startScale.y);
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

    protected virtual void Die()
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null)
            collision.GetComponent<PlayerStats>().TakeDamage(_damage);
    }

}
