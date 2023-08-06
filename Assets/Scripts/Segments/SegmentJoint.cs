using UnityEngine;
using UnityEngine.Serialization;

public class SegmentJoint : MonoBehaviour
{
    public Transform connectedSegment;

    public Vector2 anchor = new Vector2(0, 0);

    private Vector2 _baseAnchorSize;

    public void Start()
    {
        _baseAnchorSize = anchor;
    }

    public void UpdateSegmentJointPos()
    {
        if (connectedSegment == null) return;

        anchor = _baseAnchorSize * transform.localScale;

        var targetDirection = (Vector2)connectedSegment.position - (Vector2)transform.position;

        var angle = Vector3.Angle(transform.right, targetDirection) - 90;

        transform.Rotate(0, 0, angle * 0.9f);

        var anchorPos = transform.position + transform.rotation * anchor;
        var translation = (Vector2)connectedSegment.position - (Vector2)anchorPos;

        transform.position += (Vector3)translation;
    }
}
