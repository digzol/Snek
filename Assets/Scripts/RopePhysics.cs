using UnityEngine;

public class RopePhysics : MonoBehaviour
{
    public int segmentCount = 10;
    public float segmentSize = 1;

    private LineRenderer _line;
    private Vector3 _prevPosition;
    private Quaternion _prevRotation;

    private void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();
        _line.useWorldSpace = false;
        _line.positionCount = segmentCount;
        InitializePositions();
    }

    private void LateUpdate()
    {
        if (segmentCount != _line.positionCount) { _line.positionCount = segmentCount; }

        var t = transform;
        var rotation = t.rotation;
        var position = t.position;

        var worldRotation = Quaternion.Inverse(t.localRotation) * rotation;
        var rotationChange = Quaternion.Inverse(rotation) * _prevRotation;
        var localRotation = Quaternion.Inverse(worldRotation) * rotationChange;

        var parentPos = position;

        for (var i = 1; i < segmentCount; i++)
        {
            // Sets position and rotation in world space, apply translation and reverse back to local pos & rot
            var worldPos = worldRotation * _line.GetPosition(i) + _prevPosition;
            var newWorldPos = (worldPos - parentPos).normalized * segmentSize + parentPos;
            var localPos = localRotation * (newWorldPos - position);

            _line.SetPosition(i, localPos);
            parentPos = newWorldPos;
        }

        _prevPosition = position;
        _prevRotation = rotation;
    }

    private void InitializePositions()
    {
        var pos = Vector2.zero;

        _prevPosition = pos;

        for (var i = 0; i < segmentCount; i++)
        {
            _line.SetPosition(i, pos);
            ;
            pos.y += segmentSize;
        }
    }
}