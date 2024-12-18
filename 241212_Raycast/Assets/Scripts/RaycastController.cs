using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _detectionLayer;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RayShot();
        }
    }

    private void RayShot()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance, _detectionLayer))
        {
            Debug.Log(hit.transform.name);
        }
    }

    private void Init()
    {
        _cam = Camera.main;
    }


}
