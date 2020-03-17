using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    private float _time;
    protected float _effectAmount;
    private bool _isEffects;

    public PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        if (_time > 0)
        {
            if(!_isEffects)ApplyEffect();
            _time -= Time.deltaTime;
        }
        else if (_time <= 0 && _isEffects)
        {
            EndEffect();
            _isEffects = false;
        }
    }

    protected void ApplyEffect()
    {
        _isEffects = true;
         Effect();
    }

    protected virtual void Effect()
    {

    }

    protected virtual void EndEffect()
    {

    }

    public void StatusEffectSetUp(float time, float effectAmount)
    {
        _time = time;
        _effectAmount = effectAmount;
        ApplyEffect();
    }
}
