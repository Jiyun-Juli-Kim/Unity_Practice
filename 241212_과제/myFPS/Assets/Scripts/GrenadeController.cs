using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] GameObject _grenadePrefab;
    [SerializeField] private Transform  _throwPoint;
    private Grenade _grenade;

    private void Awake()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }
    

    private void Throw()
    {
        if (PlayerController.weapon == null)
        {
            return;
        }

        _grenade = PlayerController.weapon.GetComponent<Grenade>();
        Rigidbody rb = PlayerController.weapon.GetComponent<Rigidbody>();
        Debug.Log($"{ PlayerController.weapon.name}생성");


        if (_grenade != null)
        {
                rb.AddForce(_throwPoint.forward * _grenade.SetThrowForce(), ForceMode.Impulse);
                Debug.Log("발사로직");
        }

        else 
        { 
            return; 
        }
    }
}
