using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"{gameObject.name}, 생성"); 
    }

    void OnEnable()
    {
        Debug.Log($"{gameObject.name}, 활성화");
    }
}
