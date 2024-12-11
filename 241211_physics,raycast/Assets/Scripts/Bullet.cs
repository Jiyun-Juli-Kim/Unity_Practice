using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    //private void Update()
    //{
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self); // 로컬좌표계
    //}

    public void SetSpeed(Vector3 speed)
    {
        rb.velocity = speed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log($"{collision.gameObject.name} 공격");
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("다른 물체와 충돌");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Wall")
        {
            Debug.Log($"{collider.name} 충돌");
            Destroy(gameObject);
        }
    }
}
