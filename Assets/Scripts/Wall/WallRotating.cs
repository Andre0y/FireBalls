using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotating : MonoBehaviour
{
    [SerializeField] private float _rotateAngle;

    private Vector3 _rotateVector = new Vector3(0, 1, 0);

    void Update()
    {
        RotateWall(_rotateVector, _rotateAngle);  
    }

    private void RotateWall(Vector3 rotateVector, float rotateAngle)
    {
        transform.Rotate(rotateVector,rotateAngle);
    }
}
