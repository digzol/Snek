using UnityEngine;

public class BodyRenderer : MonoBehaviour {
    [Range(0, 50)] public int Segments = 50;
    [Range(0, 5)] public float XRadius = 1;
    [Range(0, 5)] public float YRadius = 1;

    private LineRenderer _line;

    private void Start() {
        _line = gameObject.GetComponent<LineRenderer>();

        _line.positionCount = Segments + 1;
        _line.useWorldSpace = false;
        CreateBody();
    }

    private void CreateBody() {
        var angle = 90f;

        for (var i = 0; i < (Segments + 1); i++) {
            var x = Mathf.Cos(Mathf.Deg2Rad * angle) * XRadius;
            var y = Mathf.Sin(Mathf.Deg2Rad * angle) * YRadius;

            _line.SetPosition(i, new Vector2(x, y));

            angle += (360f / Segments);
        }
    }
}