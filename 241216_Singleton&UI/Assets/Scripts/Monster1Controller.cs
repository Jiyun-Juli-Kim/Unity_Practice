using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 타입 1 : 플레이어가 일정거리 이상 가까워지면 플레이어에게 달려들어 공격
public class Monster1Controller : MonoBehaviour
{
    private Coroutine _coroutine;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float _mon1Speed;
    
    

    private void Update()
    {
        if (Vector3.Distance(_playerPos.position, transform.position) <= 20f)
        {
            SetCoroutine();
        }
    }

    private void SetCoroutine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(FollowPlayer());
        }

    }

    private IEnumerator FollowPlayer()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            _playerPos.position, 
            Time.deltaTime * _mon1Speed
            );
    }

}
