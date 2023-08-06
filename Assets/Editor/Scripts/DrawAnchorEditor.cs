using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SegmentJoint))]
[CanEditMultipleObjects]
public class DrawAnchorEditor : Editor
{
    public void OnSceneGUI()
    {
        var t = (SegmentJoint)target;

        var pos = t.transform.position + t.transform.rotation * t.anchor;
        var size = HandleUtility.GetHandleSize(t.anchor) * 0.1f;
        var snap = 0.1f;
        var dir = Vector3.forward;

        Handles.color = new Color(0, 0, 0);

        EditorGUI.BeginChangeCheck();
        var newTargetPos =
            Handles.Slider2D(pos, dir, Vector3.right, Vector3.up, size, Handles.CircleHandleCap, snap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(t, "Anchor position");
            t.anchor = Quaternion.Inverse(t.transform.rotation) * newTargetPos;
        }

        Handles.color = new Color(0, 0, 0);
        Handles.DrawSolidDisc(t.connectedSegment.position, Vector3.forward, size * 0.75f);
        Handles.color = new Color(0, 0.6f, 1);
        Handles.DrawSolidDisc(t.connectedSegment.position, Vector3.forward, size * 0.6f);
    }
}
