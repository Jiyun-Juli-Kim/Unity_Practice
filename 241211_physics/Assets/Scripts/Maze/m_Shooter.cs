using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_Shooter : MonoBehaviour
{
    [SerializeField] private float _shootSpeed;
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private GameObject _bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(_muzzleTransform.forward * _shootSpeed, ForceMode.Impulse);
        // 따로 관리하는게 유지보수 측면에서 좋음
    }

}
