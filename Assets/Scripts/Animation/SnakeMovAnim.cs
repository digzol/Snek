using System;
using UnityEngine;

public class SnakeMovAnim : MovementAnimator
{
    [Range(0, 100)] public float movementSpeedMin = 20.0f;
    [Range(0, 100)] public float movementSpeedMax = 40.0f;
    [Range(0, 100)] public float movementSpeedUp = 20.0f;
    [Range(0, 100)] public float movementSpeedDown = 20.0f;

    [Range(0, 100)] public float rotationSpeedMin = 2.0f;
    [Range(0, 100)] public float rotationSpeedMax = 8.0f;
    [Range(0, 100)] public float rotationSpeedUp = 1.0f;
    [Range(0, 100)] public float rotationSpeedDown = 1.0f;

    private SnakePartManager _partManager;
    private Transform _headPart;

    private float _movementSpeed;
    private float _rotationSpeed;
    
    private void Start()
    {
        _partManager = gameObject.GetComponent<SnakePartManager>();
        _headPart = _partManager.parts[0].transform;

        _movementSpeed = movementSpeedMin;
        _rotationSpeed = rotationSpeedMin;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _movementSpeed += movementSpeedUp * Time.deltaTime;
            _rotationSpeed += rotationSpeedUp * Time.deltaTime;
        }
        else
        {
            _movementSpeed -= movementSpeedDown * Time.deltaTime;
            _rotationSpeed -= rotationSpeedDown * Time.deltaTime;
        }

        _movementSpeed = Mathf.Clamp(_movementSpeed, movementSpeedMin, movementSpeedMax);
        _rotationSpeed = Mathf.Clamp(_rotationSpeed, rotationSpeedMin, rotationSpeedMax);

        var headPos = _headPart.position;
        var up = _headPart.up;
        var movDir = TargetPos - (Vector2) headPos;
        
        // Help snake turn 180°
        if (Math.Abs(Vector2.Angle(up, movDir) - 180) < 0.1)
        {
            up = Quaternion.Euler(0, 0, 1) * up;
        }

        var targetPos = Vector3.Slerp(up, movDir, _rotationSpeed * Time.deltaTime);
        targetPos.z = headPos.z;

        _headPart.up = targetPos;
        _headPart.position = Vector3.MoveTowards(headPos, headPos + _headPart.up, _movementSpeed * Time.deltaTime);

        UpdateSnakeParts();
    }

    private void UpdateSnakeParts()
    {
        foreach (var part in _partManager.parts)
        {
            var joint = part.GetComponent<SegmentJoint>();
            if (joint != null) joint.UpdateSegmentJointPos();
        }
    }
}