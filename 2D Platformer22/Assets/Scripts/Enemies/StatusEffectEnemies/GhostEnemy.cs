using UnityEngine;

public class GhostEnemy : Enemy
{
    [SerializeField]
    private float _debuffAmount;
    [SerializeField]
    private float _debuffTime;
    private float _currentCoolDown;

    private void Awake()
    {
        EnemySetUp(0, 70, 30);
        _debuffAmount = 4.5f;
        _debuffTime = 4;
    }

    private void Update()
    {
        if (_currentCoolDown <= 0)
        {
            _playerStats.AddStatusEffect<SlowDownStatusEffect>(_debuffTime, _debuffAmount);
            _currentCoolDown = _debuffTime + 2.5f;
        }
        else
            _currentCoolDown -= Time.deltaTime;
    }
}
