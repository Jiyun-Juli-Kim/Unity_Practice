using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject cube;

    void Update()
    {
        Func1();
    }

    void Func1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(cube);
        }


    }

}
