using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    // [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidBody;

    // [SerializeField] private Transform _muzzleTransform;
    // [SerializeField] private GameObject _bullet;
    // [SerializeField] private int _canonBallPoolSize;
    // private GameObject[] _cannonBallPool;

    private void Awake()
    {
        _rigidBody=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ObjectMoving();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CannonShot();
        //}
    }

    //private void Init()
    //{
    //    _rigidBody = GetComponent<Rigidbody>();
    //    _cannonBallPool = new GameObject[_canonBallPoolSize];
    //    for (int i = 0; i < _cannonBallPool.Length; i++)
    //    {
    //        _cannonBallPool[i] = Instantiate(_cannonBallPrefab);
    //        _cannonBallPool[i].SetActive(false);
    //    }
    //}

    private void ObjectMoving()
    { 
        Vector3 Direction = GetNormalizedDirection();
        if (Direction == Vector3.zero)
        {
            return;
        }

        SetRotateLerp(Direction);
        SetForwardVelocity(_moveSpeed);
    }

    private void SetRotateLerp(Vector3 direction) //방향을 부드럽게 전환
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            _rotateSpeed * Time.deltaTime
            );
    }

    private void SetForwardVelocity(float value)
    { 
        _rigidBody.velocity = transform.forward * value;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        return inputDirection.normalized;
    }

    //private void CannonShot()
    //{
    //    //foreach (var ball in _cannonBallPool) //오브젝트풀 순회
    //    //{
    //    //    if (!ball.activeSelf) //비활성포탄을 발견하면
    //    //    {
    //    //        ball.transform.position = _muzzleTransform.position; //포탄의 위치를 포신으로 변경
    //    //        ball.transform.rotation = Quaternion.LookRotation(_muzzleTransform.up); //??
    //    //        ball.SetActive(true);
    //    //        return;
    //    //    }

    //    //}

    //    GameObject instance = Instantiate(_bullet, _muzzleTransform.position, _muzzleTransform.rotation);
    //    Bullet bullet = instance.GetComponent<Bullet>();
    //    bullet.SetSpeed(_bulletSpeed*_muzzleTransform.forward);
    //}
}
