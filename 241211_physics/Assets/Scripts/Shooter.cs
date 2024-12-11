using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Rigidbody _rigidBody;

    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private GameObject _bullet;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CannonShot();
        }
    }

    private void CannonShot()
    {
        GameObject instance = Instantiate(_bullet, _muzzleTransform.position, _muzzleTransform.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetSpeed(_bulletSpeed*_muzzleTransform.forward);
    }
}
