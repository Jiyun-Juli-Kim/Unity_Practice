using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"{gameObject.name}, ����"); 
    }

    void OnEnable()
    {
        Debug.Log($"{gameObject.name}, Ȱ��ȭ");
    }
}
