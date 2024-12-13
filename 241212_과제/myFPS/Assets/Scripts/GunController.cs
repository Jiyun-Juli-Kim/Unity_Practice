using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Transform _muzzlePoint;

    [SerializeField] GameObject _bulletPrefab;

    private void Update()
    {
        BulletShoot();
    }



    private void BulletShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _muzzlePoint.position, _muzzlePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(_muzzlePoint.forward *bullet.GetComponent<Bullet>().SetSpeed(), ForceMode.Impulse);
            Destroy(bullet, 8f); 
        }
    }


}
