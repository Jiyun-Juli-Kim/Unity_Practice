using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 타입 2 : 3초에 한마리씩 스폰되며 플레이어를 향해 총알 발사
public class Mon2Controller : MonoBehaviour
{
    private Coroutine _mon2AttackCoroutine;
    [SerializeField] public Transform _playerPos;
    // 질문. 인스펙터창에서 할당할 수 없는 이유?
    [SerializeField] private Transform _bulletPos;

    [SerializeField] private float _mon2Speed;
    [SerializeField] private float _bulletSpeed = 15f;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _coolTime =1.5f;
    private Bullet _bullet;

    private void Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        _mon2AttackCoroutine = StartCoroutine(ShootPlayer());
    }

    private void Update()
    {
        SetRotation();
    }

    private void OnDestroy()
    {
        _mon2AttackCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_bulletPos.position, _playerPos.position - _bulletPos.position);
    }

    private void SetRotation()
    {
        Quaternion targetRot = Quaternion.LookRotation(_playerPos.position - _bulletPos.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 100f);
    }
    

    private IEnumerator ShootPlayer()
    {
        while (true)
        {
            _bullet = Instantiate(_bulletPrefab, _bulletPos.position, _bulletPos.rotation).GetComponent<Bullet>();
            _bullet.GetComponent<Rigidbody>().AddForce(_bulletPos.forward * _bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(_coolTime);
        }
    }

}
