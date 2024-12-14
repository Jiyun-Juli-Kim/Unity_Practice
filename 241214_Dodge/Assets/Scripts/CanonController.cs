using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private bool _isDetected = false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _cannonInterpolate;

    private Bullet _bullet;


    void Start()
    {
        
    }

    void Update()
    { 
        DetectPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_bulletPoint.position, _bulletPoint.forward * 10);
    }

    private void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(_bulletPoint.position, 10);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player") 
            { 
                _isDetected = true;
                transform.rotation =
                    Quaternion.LookRotation(collider.gameObject.transform.position);
                Debug.Log("적 감지 및 회전");

                Attack();
            }
        }
    }

    private void Attack()
    {
        if (_bullet == null)
        {
            // Instantiate(_bulletPrefab, _bulletPoint) 이렇게 하니까 엉뚱한데서 스폰되던데 왜그랬을까요 ㅠㅠㅠ
            _bullet = Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation).GetComponent<Bullet>();
            _bullet.GetComponent<Rigidbody>().AddForce(_bulletPoint.forward * _bullet.GetSpeed(), ForceMode.Impulse);
        }
    }

    //ransform.rotation = Quaternion.Lerp(
    //                transform.rotation,
    //                Quaternion.LookRotation(collider.gameObject.transform.position),
    //                _cannonInterpolate* Time.deltaTime
    //                );

}
