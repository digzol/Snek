using UnityEditor;
using UnityEngine;

public class SegmentJoint : MonoBehaviour {
    public Transform ConnectedSegment;
    public Vector2 Anchor = new Vector2(0, 0);

    private Vector2 _baseAnchorSize;

    public void Start() {
        _baseAnchorSize = Anchor;
    }

    public void UpdateSegmentJointPos() {
        if (ConnectedSegment == null) return;

        Anchor = _baseAnchorSize * transform.localScale;

        var targetDirection = ((Vector2) ConnectedSegment.position - (Vector2) transform.position);

        var angle = Vector3.Angle(transform.right, targetDirection) - 90;

        transform.Rotate(0, 0, angle * 0.9f);

        var anchorPos = transform.position + transform.rotation * Anchor;
        var translation = ((Vector2) ConnectedSegment.position - (Vector2) anchorPos);

        transform.position += (Vector3) translation;
    }
}
