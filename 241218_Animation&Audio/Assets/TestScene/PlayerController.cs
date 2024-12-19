using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        animator.SetBool("isWater", false);    
    }

    void Update()
    {
        animator.SetFloat("MoveSpeed", moveSpeed);
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log(other.tag);
            animator.SetBool("isWater", true);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            animator.SetBool("isWater", false);
        }
    }

    private void Move()
    {
        Vector3 dir = GetND();
        if (dir == Vector3.zero)
        {
            return;
        }
        transform.rotation = Quaternion.LookRotation(dir);
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private Vector3 GetND()
    {
        Vector3 iDir = Vector3.zero;
        iDir.x = Input.GetAxis("Horizontal");
        iDir.z = Input.GetAxis("Vertical");
        return iDir.normalized;
    }
    
}
