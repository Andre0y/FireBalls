using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    private float _recoilDistance = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletSpawning();
        }
    }

    public void BulletSpawning()
    {
        Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
        transform.DOMoveZ(transform.position.z - _recoilDistance, 0.03f).SetLoops(2, LoopType.Yoyo);
    }
}
