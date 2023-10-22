using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletSpawning();
        }
    }

    public void BulletSpawning()
    {
        Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity, transform);
    }
}
