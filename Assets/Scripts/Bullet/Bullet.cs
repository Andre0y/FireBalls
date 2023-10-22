using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        BulletDirection();
    }

    private void BulletDirection()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
