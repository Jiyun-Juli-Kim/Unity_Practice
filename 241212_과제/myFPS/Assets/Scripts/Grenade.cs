using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject _grenadePrefab;
    [SerializeField] private Transform  _throwPoint;
    [SerializeField] private float _throwForce;


    private Rigidbody _grenadeRb;

    void Update()
    {
        Throw();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            other.GetComponent<Enemy>().GetDamage(20f);
        }
    }

    private void Throw()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            GameObject grenade = Instantiate(_grenadePrefab, _throwPoint.position, _throwPoint.rotation);
            grenade.GetComponent<Rigidbody>().AddForce(_throwPoint.forward * _throwForce, ForceMode.Impulse);
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
