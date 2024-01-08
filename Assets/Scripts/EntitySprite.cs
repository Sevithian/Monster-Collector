using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySprite : MonoBehaviour
{
    public void Update()
    {
        var faceDirection = transform.position - Camera.main.transform.position;
        faceDirection.y = 0;
        transform.forward = faceDirection;
    }
}
