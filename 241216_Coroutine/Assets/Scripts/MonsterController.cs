using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float _monSpeed = 10f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(MonsterMove());
        
    }

    private IEnumerator MonsterMove()
    {
        float time = 0f;
        
        while (true)
        {
            transform.Translate(_monSpeed * transform.forward*Time.deltaTime);

            yield return null;
            
            time += Time.deltaTime;

            if (time >= 3)
            {
                yield return new WaitForSeconds(1f);
                transform.rotation = GetRandQuaternion();
                time = 0f;

            }

            
        }
    }

    private Quaternion GetRandQuaternion()
    {
        return Quaternion.Euler(0,Random.Range(0,360),0);
    }





}



