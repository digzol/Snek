using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform anchor;
    public float minDistance;
    public float maxDistance;
    public float movementSpeed;
    private Vector3 _anchorLastPos;

    private Camera _mainCam;

    private Vector3 _mouseLastPos;
    private Vector2 _snappedCameraPos = Vector2.zero;

    private Vector2 _velocity = Vector3.zero;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        var anchorPos = anchor.position;
        var anchorDeltaPos = anchorPos - _anchorLastPos;
        var cameraPos = transform.position;
        var mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

        var middlePos = (anchorPos + mousePos) / 2;
        var targetDir = Vector2.ClampMagnitude(middlePos - anchorPos, maxDistance);
        var targetPos = (Vector3)targetDir + anchorPos;

        if (Vector2.Distance(anchorPos, mousePos) < minDistance)
        {
            if (Input.mousePosition == _mouseLastPos && Vector2.Distance(anchorPos, cameraPos) < minDistance)
            {
                //targetPos = cameraPos;
            }

            targetPos = (anchorPos + cameraPos) / 2 + anchor.rotation * new Vector3(2.0f, 0, 0);
            // TODO: offset pos only after ~5sec not moving
        }

        //Debug.DrawLine(cameraPos, targetPos, Color.blue);

        var newPos = Vector2.SmoothDamp(cameraPos + anchorDeltaPos, targetPos, ref _velocity, movementSpeed);
        transform.position = new Vector3(newPos.x, newPos.y, cameraPos.z);

        _anchorLastPos = anchorPos;
        _mouseLastPos = Input.mousePosition;

        // TEMP GIZMOS vvv

        var center = anchorPos;
        var center2 = cameraPos;
        var angle = 0f;
        var prevLinePos = new Vector2(center.x + minDistance, center.y);
        var prevLinePos2 = new Vector2(center2.x + minDistance, center2.y);

        for (var i = 0; i <= 0; i++)
        {
            var x = Mathf.Cos(Mathf.Deg2Rad * angle) * minDistance;
            var y = Mathf.Sin(Mathf.Deg2Rad * angle) * minDistance;
            var newLinePos = new Vector2(center.x + x, center.y + y);
            var newLinePos2 = new Vector2(center2.x + x, center2.y + y);

            Debug.DrawLine(prevLinePos, newLinePos, Color.white);
            Debug.DrawLine(prevLinePos2, newLinePos2, Color.white);

            angle += 360f / 20;
            prevLinePos = newLinePos;
            prevLinePos2 = newLinePos2;
        }
    }

    private void LateUpdateX()
    {
        var anchorPos = anchor.position;
        var cameraPos = transform.position + anchorPos - _anchorLastPos;
        var mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

        var dist = Vector2.ClampMagnitude(mousePos - anchorPos, maxDistance);
        var targetPos = dist + (Vector2)anchorPos;
        var step = Vector2.Distance(cameraPos, targetPos) * movementSpeed * Time.smoothDeltaTime;
        var newPos = Vector2.MoveTowards(cameraPos, targetPos, step);

        transform.position = new Vector3(newPos.x, newPos.y, cameraPos.z);

        _anchorLastPos = anchorPos;
    }
}
