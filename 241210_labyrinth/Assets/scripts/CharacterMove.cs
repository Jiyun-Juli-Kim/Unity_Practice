using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateInterpolate;

    void Update()
    {
        MoveTo(); 
    }

    private void MoveTo()
    { 
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero) // 처리 안할시 입력이 없을 때 Vector3.zero쪽을 봄(?)
        {
            return;
        }
            transform.rotation = Quaternion.Lerp(
            transform.rotaion, 
            Quaternion.LookRotation(direction),
            rotateInterpolate*Time.deltaTime)
    }

    private void GetNormalizedDirection()
    { 
        Vector3 InputDirection = Vector3.zero // 기존값에 영향받지 않게 update시마다 초기화
        InputDirection.x = Input.GetAxis("Horizontal") // 부드러운 이동을 위해 GetAxis 사용(-1 ~ 1)
        InputDirection.z = Input.GetAxis("Vertical")
        return InputDirection.normalized; // Vector3.normalized => 방향에따라 속도 달라지지 않도록 정규화 벡터 사용
    }

}
