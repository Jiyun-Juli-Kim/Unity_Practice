using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject _gunPrefab;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetGun();
        }
    }

    private void GetGun()
    {
        GameObject gun = Instantiate(_gunPrefab, _transform.position, _transform.rotation);
        gun.transform.SetParent(_transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_transform.position, _transform.forward * 10f);
    }

    private void Shoot()
    {
        
    }
}
