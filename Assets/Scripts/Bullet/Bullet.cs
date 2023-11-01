using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    
    private float _timeForDestroy = 1.8f;

    private void Start()
    {
        _moveDirection = Vector3.forward;

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BulletDirection(_timeForDestroy);
    }

    private void BulletDirection(float timeForDestroy)
    {
        transform.Translate(_moveDirection * Time.deltaTime * _speed);
        Destroy(gameObject, timeForDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 explosionVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + Vector3.forward.z);    
        
        if (other.TryGetComponent(out Block block))
        {
            block.BulletHit?.Invoke(block);
            Destroy(gameObject);
        }

        if (other.TryGetComponent(out Wall wall))
        {
            _rigidbody.AddExplosionForce(_explosionForce, explosionVector, _explosionRadius);
            _moveDirection = Vector3.back + Vector3.up * 1.2f;

            if (transform.position.z >= 3.7f)
            {
                _moveDirection = Vector3.back + Vector3.up / 1.6f;
            }
        }
    }
}
