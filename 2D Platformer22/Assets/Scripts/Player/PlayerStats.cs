using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public Rigidbody2D Rigidbody2D { get { return GetComponent<Rigidbody2D>(); } private set { } }
    public Animator Animator { get { return GetComponentInChildren<Animator>(); } private set { } }
    public SpriteRenderer Sprite { get { return GetComponentInChildren<SpriteRenderer>(); } private set { } }

    private HealthBar _healthBar;

    private float _maxMovementSpeed;
    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    public bool DamageImmunity;

    [SerializeField] private float _maxJumpForce;
    [SerializeField] private float _jumpForce;

    private float _fireRate;
    
    private void Awake()
    {
        StatsSetUp();
        _healthBar = FindObjectOfType<HealthBar>();
    }

    public void TakeDamage(float damage)
    {
        Rigidbody2D.velocity = Vector2.zero;
        //Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _healthBar.SetHealthBar(_health);
        if (!DamageImmunity)
        {
            _health -= damage;
        }
        if (_health <= 0)
            Die();
    }

    public void Heal(float heal)
    {
        _healthBar.SetHealthBar(_health);
        _health += heal;
        if (_health >= _maxHealth)
            _health = _maxHealth;
    }

    private void Die()
    {
        Debug.Log("Ой, сорян, а смерть мне лень писать:(");
    }

    public void MovementSpeedModifier(float value)
    {
        _movementSpeed += value;
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }

    public void JumpForceModifier(float value)
    {
        _jumpForce += value;
    }

    public float GetJumpForce()
    {
        return _jumpForce;
    }

    public void FireRateModifier(float value)
    {
        _fireRate += value;
    }

    private void StatsSetUp()
    {
        _movementSpeed = 8.7f;
        _jumpForce = 5.8f;
        _maxHealth = 100f;
        _health = _maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
