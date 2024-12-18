using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _interpolation;
    [SerializeField] public float _playerHp = 100;

    private void Update() 
    {
        PlayerMove();
        CheckHp();
    }

    private void PlayerMove()
    {
        Vector3 dir = GetNormalizedDirection();

        if (dir == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), _interpolation * Time.deltaTime);
        transform.position += dir*_moveSpeed * Time.deltaTime;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDir = Vector3.zero;
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");
        return inputDir.normalized;
    }

    public void GetDamage(float damage)
    {
        if (_playerHp > 0)
        {
            _playerHp -= damage;
        }
    }

    private void CheckHp()
    {
        if (_playerHp <= 0)
        { 
            Destroy(gameObject);
        }
    }
}
