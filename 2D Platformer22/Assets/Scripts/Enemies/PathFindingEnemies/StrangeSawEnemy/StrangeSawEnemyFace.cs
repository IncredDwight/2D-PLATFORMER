using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeSawEnemyFace : MonoBehaviour
{
    private Vector3 _sawPos;

    private void Update()
    {
        _sawPos = FindObjectOfType<StrangeSawEnemy>().transform.position;
        transform.position = new Vector3(_sawPos.x, _sawPos.y, -1);
        transform.Rotate(Vector2.zero);
    }
}
