using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _playerJumpForce;
    [SerializeField] private float _rotInterpolation;

    private Camera _camera;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = this.GetComponent<Camera>();

    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float temp = _playerSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed *= 2;
        }
        
        Vector3 dir = GetND();
        transform.position += dir * _playerSpeed * Time.deltaTime;

        PlayerRotation();
        
        _playerSpeed = temp;
        
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _playerJumpForce, ForceMode.Impulse);
            Debug.Log("Jump");
        }
    }

    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += mouseX;
        
        transform.rotation = Quaternion.Euler(rot);
    }
    
    private Vector3 GetND()
    {
        Vector3 iDir = Vector3.zero;
        iDir.x = Input.GetAxis("Horizontal");
        iDir.z = Input.GetAxis("Vertical");
        return iDir.normalized;
    }
}
