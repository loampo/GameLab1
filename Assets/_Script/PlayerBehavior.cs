using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody _rb;
    private CapsuleCollider _col;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;

    public float MoveSpeed = 500f;
    public float MaxSpeed = 1000f;
    public float RotateSpeed = 75f;
    //private float acceleration = 100f;

    private float _vInput;
    private float _hInput;

    public float MinJump = 5f;
    public float MaxJump = 5f;
    private bool _isJumping;
    private bool _isMoving;
    private bool _isStop;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        _isMoving |= Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S);
        _isStop |= Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S);
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        _rb.AddForce(transform.forward * _vInput * Time.deltaTime, ForceMode.Force);

        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        //if (_isMoving && MoveSpeed <= MaxSpeed)
        //{
        //    MoveSpeed += acceleration;
        //} MoveSpeed = 0;
        

        //Transform.Rotate(Transform.up * Horizontal * (analogSensitivity * 10f) * Time.deltaTime);

        //Vector3 direction = new(0f, 0f, Vertical);
        //direction = Transform.worldToLocalMatrix.inverse * direction;

        //velocity = new(
        //    direction.x * MaxSpeed * CurrentFloorFriction,
        //    Velocity.y,
        //    direction.z * MaxSpeed * CurrentFloorFriction);
    }
    void FixedUpdate()
    {
    }
}
