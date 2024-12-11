using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject _cubePrefab;

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(_cubePrefab);
        }
    }
}
