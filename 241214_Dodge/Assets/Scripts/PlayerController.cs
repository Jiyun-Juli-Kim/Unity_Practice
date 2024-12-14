using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [Range(0, 5f)]
    [SerializeField] private float _interpolation;
    private Rigidbody _rb;

    public static GameObject weapon;
    [SerializeField] private Transform _weaponPos;

    [SerializeField] private GameObject _gunPrefab;
    [SerializeField] private GameObject _grenadePrefab;

    void Awake()
    {
        Init();
    }

    void Update()
    {
        PlayerMove();
        GetWeapon();
        SetWeaponPosition();
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void PlayerMove()
    {
        Vector3 dir = GetNormalizedDirection();
        float moveSpeed = GetSpeed();

        if (dir == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(dir),
            _interpolation * Time.deltaTime);

        transform.position += dir * moveSpeed * Time.deltaTime;


    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDir = Vector3.zero;
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");
        return inputDir.normalized;
    }

    private float GetSpeed()
    {
        float tempSpeed = _moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempSpeed *= 2;
        }

        return tempSpeed;
    }

    // 시간 남으면 후진 구현
    private void GetWeapon()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapon != null)
            {
                Destroy(weapon);
            }

            weapon = Instantiate(_gunPrefab, _weaponPos.position, _weaponPos.rotation);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weapon != null)
            {
                Destroy(weapon);
            }

            weapon = Instantiate(_grenadePrefab, _weaponPos.position, _weaponPos.rotation);
           
        }
    }

    private void SetWeaponPosition()
    {
        if (weapon != null)
        {
            weapon.transform.position = _weaponPos.position;
            weapon.transform.rotation = _weaponPos.rotation;
        }
    }
}
