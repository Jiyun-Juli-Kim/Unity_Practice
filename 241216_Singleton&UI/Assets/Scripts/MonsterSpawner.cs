using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Spawner : MonoBehaviour
{
    private Coroutine _coroutine;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private GameObject _mon2Prefab;
    private Coroutine _mon2Coroutine2;
    private void Update()
    {
        
    }

    // mon1 : 기본적으로 게임필드 위에 존재 
    // mon2 : 생성 후 3초 뒤 또 한마리 생성

    private IEnumerator MonSpawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10));
        Instantiate(_mon2Prefab, spawnPos, Quaternion.LookRotation(_playerPos.position-spawnPos));    
        yield return new WaitForSeconds(3f);
    }





}