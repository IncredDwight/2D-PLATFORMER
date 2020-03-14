using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : EnemyPathFinder
{
    private void Awake()
    {
        EnemySetUp(9, 5, 10);
    }

    
}