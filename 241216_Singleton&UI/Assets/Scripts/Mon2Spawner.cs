using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon2Spawner : MonoBehaviour
{
    private Coroutine _coroutine;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private GameObject _mon2Prefab;
    private Coroutine _mon2Coroutine;
    private void Awake()
    {
        _mon2Coroutine = StartCoroutine(Mon2Spawn());
    }

    private IEnumerator Mon2Spawn()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-15, 15), 1.322026f, Random.Range(-15, 15));
            Instantiate(_mon2Prefab, spawnPos, Quaternion.LookRotation(_playerPos.position - spawnPos));
            yield return new WaitForSeconds(5f);
        }
    }





}