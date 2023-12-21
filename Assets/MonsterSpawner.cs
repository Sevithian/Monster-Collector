using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Color drawColor = Color.red;
        drawColor.a = 0.25f;
        Gizmos.color = drawColor;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
