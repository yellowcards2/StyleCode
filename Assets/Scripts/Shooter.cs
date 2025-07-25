using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _speed;

    private Transform _target;
    private float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.Rigidbody.transform.up = direction;
            bullet.Rigidbody.linearVelocity = direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}


