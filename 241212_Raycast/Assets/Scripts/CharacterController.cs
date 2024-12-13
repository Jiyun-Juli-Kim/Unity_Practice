using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _detectSightDistance;

    private Ray _ray; // 재사용하기 위해 필드로 선언 
    private Rigidbody _rigidbody;
    public bool IsSelect;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (IsSelect)
        {
            SetMove();
            DetectObjectInFront();
        }
    }

    private void OnDrawGizmos()
    {
        if (IsSelect)
        { 
            Gizmos.color = Color.red;
            // 시작점, 방향과 거리 
            Gizmos.DrawRay(_ray.origin, _ray.direction * _detectSightDistance);
        }
    }
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void SetMove()
    {
        Vector3 direction = GetDirectionFromInput();
        if (direction == Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        _rigidbody.transform.rotation = Quaternion.Lerp(
        transform.rotation,
        Quaternion.LookRotation(direction),
        _rotateSpeed * Time.deltaTime
        );

        _rigidbody.velocity = _moveSpeed*direction;

    }

    private Vector3 GetDirectionFromInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        return dir.normalized;
    }


    private void DetectObjectInFront()
    {
        // Ray는 시작점과 방향을 갖는다 
        _ray = new Ray(transform.position, transform.forward * _detectSightDistance);
        RaycastHit hit;

        // 지정거리 내에서 Ray에 충돌하는 오브젝트를 RaycastHit에 담아두고 true를 반환할 것
        if (Physics.Raycast(_ray, out hit, _detectSightDistance))
        {
            Debug.Log($"{name} : {hit.transform.name} 발견!");
        }
    }
}
