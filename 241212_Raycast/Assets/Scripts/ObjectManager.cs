using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // ObjectManager

    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _positionScope;
    private Camera _cam;
    private CharacterController _target;
    private Transform _targetTransform;
    private Ray _ray;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        TryGetObjHandle();
    }

    private void Init()
    {
        _cam = Camera.main;

        CreateObj(_characterPrefab).name = "Kim";
    
    CreateObj(_characterPrefab).name = "Lee";
    
    CreateObj(_characterPrefab).name = "Park";
    
}

    private GameObject CreateObj(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = new Vector3(
            Random.Range(-_positionScope, _positionScope),
            0f,
          Random.Range(-_positionScope, _positionScope)
        );
        obj.transform.rotation = Quaternion.Euler(
            0,
            Random.Range(0, 360),
            0
        );

        return obj;
    }

    // 마우스 클릭으로 오브젝트 제어 권한 얻기
    private void TryGetObjHandle()
    {
        // 마우스 좌클릭
        if (Input.GetMouseButton(0))
        {
            _ray = _cam.ScreenPointToRay(Input.mousePosition);
            Raycasthit Hit;

            if (Physics.Raycast(_ray, out hit))
            {
                if (_targetTransform == hit.transform)
                {
                    return;
                }

                if (_target != null)
                {
                    _target.IsSelect = false;
                }
                _targetTransform = hit.transform;
                _target = _targetTransform.GetComponent<CharacterController>();
                _target.IsSelect = true;

            }

        }

    }
}
