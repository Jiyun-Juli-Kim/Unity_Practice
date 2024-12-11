using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_Shooter : MonoBehaviour
{
    [SerializeField] private float _shootSpeed;
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private GameObject _bulletPrefab;


    private void Awake()
    {
        
    }

    void Update()
    {
        Init();
    }

    private void Init()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject instance = Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * _shootSpeed * Time.deltaTime, ForceMode.Impulse);
    }

}
