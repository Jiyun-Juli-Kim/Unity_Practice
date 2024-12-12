using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float _totalDamage;

    private void Update()
    {
        Break();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            _totalDamage += 3;
        }
    }

    private void Break()
    {
        if (_totalDamage > 10)
        {
            Destroy(this.gameObject);
        }
    }

}
