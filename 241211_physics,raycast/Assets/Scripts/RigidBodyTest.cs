using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyTest : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _force;
    [SerializeField] private float _velocityValue;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // _rigidBody.AddForce(Vector3.up * _force, ForceMode.Impulse);
            // _rigidBody.AddTorque(Vector3.up * _force);
            // _rigidBody.velocity = Vector3.up * _velocityValue;
            _rigidBody.angularVelocity = Vector3.up * _velocityValue;

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
        }
    }


}
