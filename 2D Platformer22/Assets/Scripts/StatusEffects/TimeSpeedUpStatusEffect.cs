using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpeedUpStatusEffect : StatusEffect
{
    protected override void Effect()
    {
        Time.timeScale += _effectAmount;
    }

    protected override void EndEffect()
    {
        Time.timeScale -= _effectAmount;
    }
}
