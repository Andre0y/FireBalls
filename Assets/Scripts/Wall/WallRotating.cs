using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotating : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, 0.6f);  
    }
}
