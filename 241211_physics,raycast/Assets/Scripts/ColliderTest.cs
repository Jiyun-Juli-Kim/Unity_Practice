using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    // 충돌시작시점에서 1회호출
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어와 닿았다</color>");
        }
    }

    // 충돌중 지속적 호출 
    // other: 충돌 대상 
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어와 닿아있다</color>");
        }
    }

    // 충돌 종료시 1회 호출 
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어와 떨어졌다</color>");
        }
    }

    private void FixedUpdate()
    {
        Debug.Log($"<color=#ad6cf3>Fixed Update 호출, 이전 호출로부터 {Time.fixedDeltaTime}</color>");

    }

    private void Update()
    {
        Debug.Log($"Update 호출, 이전 호출로부터 {Time.deltaTime}");
    }

}
