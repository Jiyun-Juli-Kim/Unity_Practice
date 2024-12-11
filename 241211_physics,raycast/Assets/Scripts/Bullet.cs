using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    //private void Update()
    //{
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self); // ������ǥ��
    //}

    public void SetSpeed(Vector3 speed)
    {
        rb.velocity = speed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log($"{collision.gameObject.name} ����");
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("�ٸ� ��ü�� �浹");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Wall")
        {
            Debug.Log($"{collider.name} �浹");
            Destroy(gameObject);
        }
    }
}
