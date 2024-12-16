using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _petSpeed=3f;

    [SerializeField] private float _stopDistance = 0.5f;
    private Coroutine _callCoroutine;
    // IEnumerator, Coroutine 타입의 차이?
    public void MoveToPlayer()
    {
        if (_callCoroutine == null)
        {
            _callCoroutine = StartCoroutine(CallCoroutine());
            Debug.Log("코루틴 호출");
        }
    }

    
    // 프레임단위로 이동하고, 플레이어 객체와의 거리가 일정 실수 이하가 되면 정지
    private IEnumerator CallCoroutine()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) <= _stopDistance)
            {
                _callCoroutine = null;
                Debug.Log("코루틴 작동 중지");
                yield break;
            }

            transform.position = Vector3.MoveTowards(transform.position, 
                _player.transform.position,
                Time.deltaTime * _petSpeed);
            Debug.Log("코루틴 작동중");

            yield return null;
        }
    }
}