using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotationNiv3 : MonoBehaviour
{

    [SerializeField] private float _rotationSpeedY = 0.5f;

    
    void Update()
    {
        transform.Rotate(0f, _rotationSpeedY, 0f); 
    }
}
