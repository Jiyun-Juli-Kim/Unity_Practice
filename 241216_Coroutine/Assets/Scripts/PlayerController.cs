using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;

    [field: SerializeField] public UnityEvent OnPetCalled { get; private set; } = new();
    // 여기서 field, new의 의미
        
    void Update()
    {
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.C))
        {
            CallPet();
        }
    }

    private void CallPet()
    {
        OnPetCalled.Invoke();
    }

    private void PlayerMove()
    {
        Vector3 dir = GetNormalizedDirection();
        if (dir == Vector3.zero)
        {
            return;
        }
        
        transform.rotation = Quaternion.LookRotation(dir);
        transform.position += dir * (_moveSpeed * Time.deltaTime) ;
        
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 iDir = Vector3.zero;
        iDir.x = Input.GetAxis("Horizontal");
        iDir.z = Input.GetAxis("Vertical");
        return iDir;
    }
}
