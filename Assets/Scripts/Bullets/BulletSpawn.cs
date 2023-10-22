using System;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    public Bullet BulletSpawning()
    {
        return Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity, transform); 
    }
}