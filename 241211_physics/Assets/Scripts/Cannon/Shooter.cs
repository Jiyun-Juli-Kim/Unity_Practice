using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Rigidbody _rigidBody;

    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private Bullet _bullet;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CannonShot();
        }
    }

    private void CannonShot()
    {
        Bullet bullet = Instantiate(_bullet, _muzzleTransform.position, _muzzleTransform.rotation);
        bullet.SetSpeed(_bulletSpeed*_muzzleTransform.forward);
    }
}
