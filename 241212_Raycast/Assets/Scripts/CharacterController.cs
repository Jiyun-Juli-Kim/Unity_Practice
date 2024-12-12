using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _detectSightDistance;

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
        dir.x = Input.GetAxisRaw("Vertical");
        return dir.normalized;
    }


    private void DetectObjectInFront()
    {
        // Ray는 시작점과 방향을 갖는다 
        Ray ray = new Ray(transform.position, transform.forward * _detectSightDistance);
        RaycastHit hit;

        // 지정거리 내에서 Ray에 충돌하는 오브젝트를 RaycastHit에 담아두고 true를 반환할 것
        if (Physics.Raycast(ray, out hit, _detectSightDistance))
        {
            Debug.Log($"{name} : {hit.transform.name} 발견!");
        }
    }
}
