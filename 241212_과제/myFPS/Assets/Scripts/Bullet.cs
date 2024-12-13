using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        { 
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(10f);
            Destroy(gameObject);
        }
    }

    public float SetSpeed()
    { 
        return _bulletSpeed;
    }
}
