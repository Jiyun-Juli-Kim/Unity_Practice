using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // [SerializeField] private float _bulletSpeed;
    [SerializeField] private Transform _muzzlePoint;

    // [SerializeField] GameObject _bulletPrefab;
    [Range(1,20)]
    [SerializeField] float _rayLength;

    private void Update()
    {
        BulletShoot2();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_muzzlePoint.position, _muzzlePoint.forward* _rayLength);
    }

    private void BulletShoot2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength))
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<Enemy>().GetDamage(10);
                }
            }
        }
       
    }

    //private void BulletShoot()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject bullet = Instantiate(_bulletPrefab, _muzzlePoint.position, _muzzlePoint.rotation);
    //        bullet.GetComponent<Rigidbody>().AddForce(_muzzlePoint.forward *bullet.GetComponent<Bullet>().SetSpeed(), ForceMode.Impulse);
    //        Destroy(bullet, 8f); 
    //    }
    //}


}
