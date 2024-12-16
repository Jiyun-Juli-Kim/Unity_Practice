using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab;
    private Coroutine _coroutine;
    private Queue<GameObject> _monstersQue;

    private void Awake()
    {
        _monstersQue = new Queue<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Spawn());
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
             Delete();
        }
    }

    private IEnumerator Spawn()
    {
        Vector3 pos = new Vector3 (Random.Range(-20,20),0,Random.Range(-20,20));
        Vector3 rot = new Vector3 (0,Random.Range(-180,180), 0);

        yield return new WaitForSeconds(2f);
        _monstersQue.Enqueue(Instantiate(_monsterPrefab, pos, Quaternion.LookRotation(rot)));
        _coroutine = null;
    }

    private void Delete()
    {
        if (_monstersQue.Count > 0)
        {
            Debug.Log("제거");
            Destroy(_monstersQue.Dequeue(), 1f);
        }
    
    }
}
