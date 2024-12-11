using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;
    [SerializeField] float _rotateInterpolate;

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 direction = GetNormalizedDirection();

        if (direction == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            _rotateInterpolate * _rotateSpeed*Time.deltaTime
            );

        transform.position += direction * _moveSpeed * Time.deltaTime;

    }


    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        return inputDirection.normalized;
    }
}
