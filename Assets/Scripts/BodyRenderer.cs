using UnityEngine;
using UnityEngine.Serialization;

public class BodyRenderer : MonoBehaviour
{
    [Range(0, 50)]
    public int segments = 50;

    [Range(0, 5)]
    public float xRadius = 1;

    [Range(0, 5)]
    public float yRadius = 1;

    private LineRenderer _line;

    private void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();

        _line.positionCount = segments + 1;
        _line.useWorldSpace = false;
        CreateBody();
    }

    private void CreateBody()
    {
        var angle = 90f;

        for (var i = 0; i < segments + 1; i++)
        {
            var x = Mathf.Cos(Mathf.Deg2Rad * angle) * xRadius;
            var y = Mathf.Sin(Mathf.Deg2Rad * angle) * yRadius;

            _line.SetPosition(i, new Vector2(x, y));

            angle += 360f / segments;
        }
    }
}
