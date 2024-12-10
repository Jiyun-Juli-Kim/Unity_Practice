using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2f;
    [SerializeField] private float Interpolation;

    private void Update()
    {
        MoveTo();
    }

    private void MoveTo()
    {    
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.Lerp(
        transform.rotation, Quaternion.LookRotation(direction),
        Interpolation* Time.deltaTime
        );
        
        transform.position += MoveSpeed* Time.deltaTime*direction;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection.x = Input.GetAxisRaw("Horizontal");
        targetDirection.z = Input.GetAxisRaw("Vertical");

        return targetDirection.normalized;
    }

}
