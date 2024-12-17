using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Controller : MonoBehaviour
{
    private Coroutine _coroutine;
    [SerializeField] private Transform _playerPos;

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
        transform.position = Vector3.Lerp(transform.position, _playerPos.position, Time.deltaTime * _mon1Speed);
        
    }

}
