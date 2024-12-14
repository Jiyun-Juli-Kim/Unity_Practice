using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _throwForce;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Invoke("Explode", 3f);
        }
    }

    public float SetThrowForce()
    {
        return _throwForce;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                colliders[i].GetComponent<Enemy>().GetDamage(20);
            }
        }

        Destroy(gameObject);
    }
}
