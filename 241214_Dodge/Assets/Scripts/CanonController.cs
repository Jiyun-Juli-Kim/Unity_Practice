using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private bool _isDetected=false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;


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
        Debug.Log("B Point is " + _bulletPoint.position);
    }

    private void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(_bulletPoint.position, 10);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player") 
            { 
                _isDetected = true;
                Debug.Log("적 감지");
                Attack();
            }
        }
    }

    private void Attack() 
    { 
        GameObject bullet = Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation);
        // Instantiate(_bulletPrefab, _bulletPoint) 이렇게 하니까 엉뚱한데서 스폰되던데 왜그랬을까요 ㅠㅠㅠ
    }


}
