using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private BulletSpawn _bulletSpawn;
    private Bullet _bulletOnScene;
    
    private void Start()
    {
        _bulletSpawn = GetComponent<BulletSpawn>();
    }

    private void Update()
    {
        BulletShooting();
        _bulletOnScene.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void BulletShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _bulletOnScene = _bulletSpawn.BulletSpawning();
        }
    }
}
