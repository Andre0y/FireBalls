using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _speed;
    private Bullet _bulletOnScene;
    private Bullet _bulletForSpawn;

    private void Update()
    {
        BulletShot();
        _bulletOnScene = BulletShot();

        BulletDirection();
    }
    
    private Bullet BulletShot()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            _bulletForSpawn = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity, transform); 
        }
        return _bulletForSpawn;
    }

    private void BulletDirection()
    {
        _bulletOnScene.transform.Translate(Vector3.forward * Time.fixedDeltaTime * _speed);
    }

    
}