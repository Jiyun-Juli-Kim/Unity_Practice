using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // 충돌시작시점에서 1회호출
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어가 영역에 들어왔다</color>");
        }
    }

    // 충돌중 지속적 호출 
    // other: 충돌 대상 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어가 영역 내에 존재한다</color>");
        }
    }

    // 충돌 종료시 1회 호출 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("<color=#fe6857>플레이어가 영역에서 나갔다</color>");
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
